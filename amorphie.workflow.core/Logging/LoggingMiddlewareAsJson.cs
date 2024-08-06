using amorphie.workflow.core.Helper;
using Google.Rpc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace amorphie.workflow.core.Logging;

public class LoggingMiddlewareAsJson
{

    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly LoggingOptions _loggingOptions;
    // private readonly List<string> redactedHeaders = ["authorization", "authentication", "client_secret", "x-userinfo"];
    // private readonly string[] redactedResponse = ["access_token", "refresh_token", "client_secret", "x-userinfo", "authorization"];
    private readonly List<string> ignorePaths = ["/health", "/swagger", "/js", "/css"];
    public LoggingMiddlewareAsJson(RequestDelegate next, ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        _loggingOptions = loggingOptions;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stream? originalResponseBody = null;
        JsonObject requestInfo = new JsonObject();
        JsonObject responseInfo = new JsonObject();
        try
        {
            //if path is ignored do not log
            if (context.Request.Path.HasValue && _loggingOptions.IgnorePaths != null && Array.Exists(_loggingOptions.IgnorePaths, context.Request.Path.Value.Contains))
            {
                await _next(context);
            }
            else
            {
                requestInfo = await LogRequest(context);


                if (_loggingOptions.LogResponse)
                {
                    responseInfo = await InvokeInternalAsync(context, originalResponseBody);
                }
                else
                {
                    await _next(context);
                    responseInfo = LogResponseHeaders(context);
                }
                _logger.LogInformation("Request : {Request}, Response : {Response}", requestInfo, responseInfo);
                //_logger.LogInformation("Request : {Request}, Response : {Response}", WfJsonSerializer.Serialize(requestInfo), WfJsonSerializer.Serialize(responseInfo));
            }
        }
        catch (Exception ex)
        {
            if (originalResponseBody != null)
            {
                context.Response.Body = originalResponseBody;
            }
            await HandleExceptionAsync(context, ex, requestInfo, responseInfo);
        }
    }


    private async Task<JsonObject?> InvokeInternalAsync(HttpContext context, Stream originalResponseBody)
    {
        JsonObject responseInfo = new JsonObject();
        using var newResponseBody = new MemoryStream();

        //Buffer response body
        originalResponseBody = context.Response.Body;
        context.Response.Body = newResponseBody;

        await _next(context);

        //Read response body
        newResponseBody.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(newResponseBody).ReadToEndAsync();

        //Rewind and set to originalResponseBody
        newResponseBody.Seek(0, SeekOrigin.Begin);
        await newResponseBody.CopyToAsync(originalResponseBody);
        var responseBody = LogResponseBody(responseBodyText);
        responseInfo.Add("Response Headers", LogResponseHeaders(context));
        if (responseBody != null)
        {
            responseInfo.Add("Response", responseBody);

        }
        else
        {
            responseInfo.Add("Response", responseBodyText);
        }
        //responseInfo = $"{LogResponseHeaders(context)} {Environment.NewLine} {responseBody}";
        return responseInfo;
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, JsonObject? requestInfo, JsonObject? responseInfo)
    {
        var errorMessage = "An error occured and logged. Use trace identifier id to find out details";
        var errorDto = new ErrorModel
        {
            ErrorMessage = errorMessage,
            TraceIdentifier = context.TraceIdentifier,
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex is BadHttpRequestException badEx ? badEx.StatusCode : (int)HttpStatusCode.InternalServerError;
        _logger.LogError(ex, "TraceIdentifier : {TraceIdentifier}. Request : {Request}, Response : {Response}", context.TraceIdentifier, requestInfo, responseInfo);
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
    }

    private async Task<JsonObject> LogRequest(HttpContext context)
    {
        JsonObject requestInfo = new JsonObject();

        var request = context.Request;
        requestInfo.Add("Http", $"{request.Method} {request.Path}");
        requestInfo.Add("Host", $"{request.Host}");
        requestInfo.Add("Request", $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}");
        var headerText = RequestHeaders(context);
        requestInfo.Add("Headers", headerText);

        if (_loggingOptions.LogRequest)
        {
            string rawRequestBody = await GetRawBodyAsync(context.Request);
            requestInfo.Add("Content", rawRequestBody);
        }
        return requestInfo;
    }

    private JsonObject RequestHeaders(HttpContext httpContext)
    {
        JsonObject requestHeaders = new JsonObject();
        foreach (var pair in httpContext.Request.Headers)
        {
            if (_loggingOptions.SanitizeHeaderNames?.Contains(pair.Key.ToLower()) == true)
            {
                requestHeaders.Add(pair.Key, "***");
            }
            else
            {
                //requestHeaders.Add(pair.Key, $"{string.Join(",", pair.Value.ToList())}");
                requestHeaders.Add(pair.Key, pair.Value.ToString().Replace("\"",""));
            }
        }
        return requestHeaders;
    }

    private async Task<string> GetRawBodyAsync(HttpRequest request, Encoding? encoding = null)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8, leaveOpen: true);
        string body = await reader.ReadToEndAsync().ConfigureAwait(false);
        request.Body.Position = 0;

        return body;
    }


    private JsonObject LogResponseHeaders(HttpContext context)
    {
        var response = context.Response;
        var responseLog = new JsonObject
        {
            { "HTTP", response.StatusCode },
            { "Content-Type", response.ContentType },
            { "Content-Length", response.ContentLength }
        };
        return responseLog;
    }

    private JsonObject LogResponseBody(string responseBodyText)
    {
        var responseAsJson = WfJsonSerializer.Deserialize<JsonObject>(responseBodyText);
        if (responseAsJson == null)
        {
            return null;
        }
        if (_loggingOptions.SanitizeFieldNames != null && _loggingOptions.SanitizeFieldNames.Length > 0)
        {
            responseAsJson = LoggingHelperAsJson.FilterResponse(responseAsJson, _loggingOptions.SanitizeFieldNames);
        }
        return responseAsJson;
    }


    private class ErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? TraceIdentifier { get; set; }
    }
}