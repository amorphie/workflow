using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Extensions;
using amorphie.workflow.service.Filters;
using amorphie.workflow.service.Zeebe;
using Elastic.Apm.Api;
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

        var transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction ??
                                      Elastic.Apm.Agent.Tracer.StartTransaction("HttpWorker", ApiConstants.TypeUnknown);
        transaction.SetLabel(ZeebeVariableKeys.InstanceId, instanceIdAsString);
        // var span = transaction.StartSpan($"HttpWorker-{url}", "");
        // span.SetLabel("InstanceId", instanceIdAsString);

        if (string.IsNullOrEmpty(url))
        {
            // span.End();
            throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'url' is mandatory");
        }
        transaction.SetLabel(ZeebeVariableKeys.Url, url);



        // span.SetLabel("HttpWorker.Url", url);
        // foreach (var result in resultList)
        // {
        //     var span = transaction.StartSpan($"Rules-{result.Rule.RuleName}", ApiConstants.TypeUnknown);
        //     span.SetLabel("Rules.", result.)
        // }

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
            catch (Exception ex)
            {
                transaction.CaptureException(ex);

                throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'acceptHeaders' is not allowed format");
            }
            transaction.SetLabel("acceptHeaders", acceptHeadersAsString);
        }



        string httpMethodName;
        //Note: Exception never occurs
        try
        {
            httpMethodName = request.Headers["method"].ToString();

            if (string.IsNullOrEmpty(httpMethodName))
            {
                httpMethodName = body.GetProperty("method")?.ToString() ?? "GET";
            }

        }
        catch
        {
            httpMethodName = "GET";
        }
        transaction.SetLabel("httpMethodName", httpMethodName);


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

        transaction.SetLabel("failureCodes", failureCodes);


        string content = string.Empty;
        try
        {
            content = body.GetProperty("body").ToString();
        }
        catch
        {
            //content already has default
        }

        transaction.SetLabel("body", content);



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
            transaction.CaptureException(ex);

        }
        transaction.SetLabel("response", responseBody);
        transaction.SetLabel("statusCode", statusCode);

        if (FailureCodesControl(failureCodes, statusCode))
        {
            throw new ZeebeBussinesException(errorCode: statusCode, errorMessage: responseBody);
        }
        var messageVariables = CreateMessageVariables(responseBody, statusCode, content, url);
        // span.End();
        return Results.Ok(messageVariables);
    }
    private static bool FailureCodesControl(string failureCodes, string statusCode)
    {

        string[] failCodes = failureCodes.Split(',');
        return failCodes.Any(a => { var match = Regex.Match(statusCode, a.Replace("x", @"\d")); return match.Success; });

    }
    private static dynamic CreateMessageVariables(string body, string statuscode, string requestBody, string url)
    {
        dynamic variables = new Dictionary<string, dynamic>();
        try
        {
            dynamic deserializedBody = JsonSerializer.Deserialize<JsonElement>(body);
            ///var filteredBody = await FilterBodyAsync(deserializedBody, url, dbContext);
            variables.Add("bodyHttpWorker", deserializedBody);
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
                    return await FilterHelper.FilterResponseAsync(body, await JsonSchema.FromJsonAsync(jsonSchemaEntity.Schema));
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

