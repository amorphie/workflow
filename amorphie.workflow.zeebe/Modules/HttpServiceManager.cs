using System.Text;
using System.Text.RegularExpressions;
using amorphie.workflow.core.Constants;
using amorphie.workflow.service.Zeebe;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
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
    static async ValueTask<IResult> HttpWorker(
           [FromBody] dynamic body,
           [FromServices] WorkflowDBContext dbContext,
           HttpRequest request,
           HttpContext httpContext,
           [FromServices] DaprClient client,
           [FromServices] IZeebeCommandService zeebeCommandService,
           [FromServices] IHttpClientFactory httpClientFactory,
            CancellationToken cancellationToken,
            IConfiguration configuration
       )
    {
        //For fetching gateway from db
        // string workFlowName = body.GetProperty("EntityName").ToString();
        // ZeebeMessage? zeebeMessage = await dbContext.ZeebeMessages.FirstOrDefaultAsync(p => p.Process == workFlowName);
        // if (zeebeMessage is null)
        // {
        //     return Results.BadRequest("Workflow/Entity Name must be in variable list");
        // }
        var instanceIdAsString = body.GetProperty(ZeebeVariableKeys.InstanceId).ToString();
        Guid instanceId;
        if (!Guid.TryParse(instanceIdAsString, out instanceId))
        {
            return Results.BadRequest("InstanceId not provided or not as a GUID");
        }
        httpContext.Items.Add(ZeebeVariableKeys.InstanceId, instanceIdAsString);
        var url = body.GetProperty("url").ToString();

        var acceptHeadersAsString = string.Empty;
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
                acceptHeaders = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(acceptHeadersAsString);
            }
            catch (Exception)
            {
                throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'acceptHeaders' is not allowed format");
            }
        }

        if (string.IsNullOrEmpty(url))
        {
            //return Results.BadRequest("Header parameter 'url' is mandatory");
            throw new ZeebeBussinesException(errorCode: "400", errorMessage: "Input parameter 'url' is mandatory");
        }

        string httpMethodName;
        //Note: Exception never occurs
        try
        {
            httpMethodName = request.Headers["method"].ToString();
            if (string.IsNullOrEmpty(httpMethodName))
                httpMethodName = "GET";
        }
        catch (Exception ex)
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
        catch (Exception ex)
        {

        }

        string content = string.Empty;
        try
        {
            content = body.GetProperty("body").ToString();
        }
        catch (Exception ex)
        {

        }

        var serialized = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
        string authorizationHeader = string.Empty;
        try
        {
            authorizationHeader = body.GetProperty("authorization").ToString();
        }
        catch (Exception ex)
        {
        }
        HttpResponseMessage response = await HttpClientSendAsync(httpClientFactory, httpMethodName, url, acceptHeaders, serialized, authorizationHeader);
        int statusCodeInt = (int)response!.StatusCode;
        var statusCode = statusCodeInt.ToString();
        string responseBody;

        try
        {
            var byteArray = await response.Content.ReadAsByteArrayAsync();
            responseBody = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
        }
        catch (Exception ex)
        {
            responseBody = "";
            Log.Fatal($"Exception while reading response body: {ex}");

        }
        if (FailureCodesControl(failureCodes, statusCode))
        {
            throw new ZeebeBussinesException(errorCode: statusCode, errorMessage: responseBody);
        }

        return Results.Ok(createMessageVariables(responseBody, statusCode, content));
    }
    private static bool FailureCodesControl(string failureCodes, string statusCode)
    {

        string[] failCodes = failureCodes.Split(',');
        return failCodes.Any(a => { var match = Regex.Match(statusCode, a.Replace("x", @"\d")); return match.Success; });

    }
    private static dynamic createMessageVariables(string body, string statuscode, string requestBody)
    {
        dynamic variables = new Dictionary<string, dynamic>();
        try
        {
            variables.Add("bodyHttpWorker", System.Text.Json.JsonSerializer.Deserialize<dynamic>(body));
        }
        catch (Exception)
        {
            variables.Add("bodyHttpWorker", body);
        }

        variables.Add("statuscode", statuscode);
        try
        {
            variables.Add("requestBody", System.Text.Json.JsonSerializer.Deserialize<dynamic>(requestBody));
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
}

