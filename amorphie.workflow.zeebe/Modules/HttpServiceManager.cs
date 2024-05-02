using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Extensions;
using amorphie.workflow.service.Filters;
using amorphie.workflow.service.Zeebe;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NJsonSchema;
using Serilog;

namespace amorphie.workflow.zeebe.Modules;

public static class HttpServiceManagerModule
{
    public static void MapHttpServiceManagerEndpoints(this WebApplication app)
    {
        app.MapPost("/amorphie-http-worker", HttpWorker)
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Maps amorphie-workflow-set-state service worker on Zeebe";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                return operation;
            });
    }
    static async ValueTask<IResult> HttpWorker([FromBody] dynamic body, HttpRequest request, HttpContext httpContext, [FromServices] IHttpClientFactory httpClientFactory, [FromServices] WorkflowDBContext dbContext)
    {
        var instanceIdAsString = body.GetProperty(ZeebeVariableKeys.InstanceId).ToString();
        Guid instanceId;
        if (!Guid.TryParse(instanceIdAsString, out instanceId))
        {
            return Results.BadRequest("InstanceId not provided nor as a GUID");
        }
        httpContext.Items.Add(ZeebeVariableKeys.InstanceId, instanceIdAsString);
        var url = body.GetProperty("url").ToString();
        if (string.IsNullOrEmpty(url))
        {
            throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'url' is mandatory");
        }
        string? acceptHeadersAsString;
        try
        {
            acceptHeadersAsString = body.GetProperty("acceptHeaders").ToString();
        }
        catch (Exception)
        {
            acceptHeadersAsString = string.Empty;
        }
        Dictionary<string, string> acceptHeaders = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(acceptHeadersAsString))
        {
            try
            {
                if (!string.IsNullOrEmpty(acceptHeadersAsString))
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    acceptHeaders = JsonSerializer.Deserialize<Dictionary<string, string>>(acceptHeadersAsString);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            catch (Exception)
            {
                throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'acceptHeaders' is not allowed format");
            }
        }

        string httpMethodName;
        //Note: Exception never occurs
        try
        {
            httpMethodName = request.Headers["method"].ToString();
            if (string.IsNullOrEmpty(httpMethodName))
                httpMethodName = "GET";
        }
        catch
        {
            return Results.BadRequest("Header parameter 'method' value is not allowed Try one of them this values => post | get | put | delete | patch");
        }

        string failureCodes = "5xx";
        try
        {
            failureCodes = request.Headers["failureCodes"].ToString();
            if (string.IsNullOrEmpty(failureCodes))
                failureCodes = "5xx";
        }
        catch
        {
            //failureCodes already has default
        }

        string content = string.Empty;
        try
        {
            content = body.GetProperty("body").ToString();
        }
        catch
        {
            //content already has default
        }

        var serialized = new StringContent(content, Encoding.UTF8, "application/json");
        string authorizationHeader = string.Empty;
        try
        {
            authorizationHeader = body.GetProperty("authorization").ToString();
        }
        catch
        {
            //authorizationHeader already has default
        }
        HttpResponseMessage response = await HttpClientSendAsync(httpClientFactory, httpMethodName, url, acceptHeaders, serialized, authorizationHeader);
        int statusCodeInt = (int)response!.StatusCode;
        var statusCode = statusCodeInt.ToString();
        string responseBody;

        try
        {
            responseBody = await ExtractResponseBodyAsync(response);
        }
        catch (Exception ex)
        {
            responseBody = "";
            Log.Fatal("Exception while reading response body: Exception : {Ex}", ex);

        }
        if (FailureCodesControl(failureCodes, statusCode))
        {
            throw new ZeebeBussinesException(errorCode: statusCode, errorMessage: responseBody);
        }
        var messageVariables = await CreateMessageVariablesAsync(responseBody, statusCode, content, url, dbContext);

        return Results.Ok(messageVariables);
    }
    private static bool FailureCodesControl(string failureCodes, string statusCode)
    {

        string[] failCodes = failureCodes.Split(',');
        return failCodes.Any(a => { var match = Regex.Match(statusCode, a.Replace("x", @"\d")); return match.Success; });

    }
    private static async Task<dynamic> CreateMessageVariablesAsync(string body, string statuscode, string requestBody, string url, WorkflowDBContext dbContext)
    {
        dynamic variables = new Dictionary<string, dynamic>();
        try
        {
            dynamic deserializedBody = JsonSerializer.Deserialize<JsonElement>(body);
            var filteredBody = await FilterBodyAsync(deserializedBody, url, dbContext);
            variables.Add("bodyHttpWorker", filteredBody);
        }
        catch (Exception ex)
        {
            Log.Fatal("HttpManager Exception : body couldnt be parsed to JsonElement. Url : {Url} Exception : {Ex} Body : {Body}", url, ex, body);
            variables.Add("bodyHttpWorker", body);
        }

        variables.Add("statuscode", statuscode);
        try
        {
            variables.Add("requestBody", JsonSerializer.Deserialize<dynamic>(requestBody));
        }
        catch (Exception)
        {
            variables.Add("requestBody", requestBody);
        }
        return variables;
    }
    private static async Task<HttpResponseMessage> HttpClientSendAsync(IHttpClientFactory httpClientFactory, string httpMethod, string url,
     Dictionary<string, string> acceptHeaders, HttpContent? serialized, string? authorizationHeader = null
    )
    {
        var client = httpClientFactory.CreateClient("httpWorkerService");
        if (!string.IsNullOrEmpty(authorizationHeader))
            client.DefaultRequestHeaders.Add("Authorization", authorizationHeader);
        var httpRequestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), url);
        if (acceptHeaders.Any())
        {
            foreach (var item in acceptHeaders)
            {
                httpRequestMessage.Headers.Add(item.Key, item.Value);
            }
        }
        if (httpRequestMessage.Method != HttpMethod.Get && serialized != null)
        {
            httpRequestMessage.Content = serialized;
        }
        return await client.SendAsync(httpRequestMessage);
    }

    private static async Task<string> ExtractResponseBodyAsync(HttpResponseMessage httpResponse)
    {
        var byteArray = await httpResponse.Content.ReadAsByteArrayAsync();
        return Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
    }

    private static async Task<dynamic> FilterBodyAsync(JsonElement body, string url, WorkflowDBContext dbContext)
    {
        if (body.TryConvertToDictionary(out Dictionary<string, object>? pairs) && pairs != null)
        {
            try
            {
                var jsonSchemaEntity = await dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.SubjectName == url);
                if (jsonSchemaEntity != null)
                {
                    return await FilterHelper.FilterResponseAsync(body,jsonSchemaEntity.Schema);
                }
                else return body;
            }
            catch (Exception ex)
            {
                Log.Fatal("HttpManager Exception : while filtering response body. Url : {Url} Exception : {Ex} Body : {Body}", url, ex, body);
                return body;
            }
        }
        return body;
    }




}

