using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace amorphie.workflow.core.Logging;

public class LoggingMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly LoggingOptions _loggingOptions;
    private const string _logTemplate = "RequestMethod : {RequestMethod}, RequestBody : {RequestBody}, RequestHost : {RequestHost}, RequestHeader : {RequestHeader}, ResponseBody : {ResponseBody}, ResponseStatus : {ResponseStatus}";
    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        _loggingOptions = loggingOptions;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stream? originalResponseBody = null;
        string? requestHeaders = null;
        string? requestBody = null;
        string? responseBody = null;
        try
        {
            //if path is ignored do not log
            if (context.Request.Path.HasValue && _loggingOptions.IgnorePaths != null && Array.Exists(_loggingOptions.IgnorePaths, context.Request.Path.Value.Contains))
            {
                await _next(context);
            }
            else
            {
                requestHeaders = LogRequestHeaders(context);
                requestBody = await LogRequestBodyAsync(context.Request);
                if (_loggingOptions.LogResponse)
                {
                    //Buffer response body
                    using var newResponseBody = new MemoryStream();
                    originalResponseBody = context.Response.Body;
                    context.Response.Body = newResponseBody;
                    responseBody = await InvokeInternalAsync(context, originalResponseBody, newResponseBody);
                }
                else
                {
                    await _next(context);
                }
                _logger.LogInformation(_logTemplate,
                    context.Request.Method,
                    requestBody,
                    context.Request.Host,
                    requestHeaders,
                    responseBody,
                    context.Response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            if (originalResponseBody != null)
            {
                context.Response.Body = originalResponseBody;
            }
            await HandleExceptionAsync(context, ex, requestHeaders, requestBody, responseBody);
        }
    }


    private async Task<string?> InvokeInternalAsync(HttpContext context, Stream originalResponseBody, MemoryStream newResponseBody)
    {
        await _next(context);
        //Read response body
        newResponseBody.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(newResponseBody).ReadToEndAsync();

        //Rewind and set to originalResponseBody
        newResponseBody.Seek(0, SeekOrigin.Begin);
        await newResponseBody.CopyToAsync(originalResponseBody);

        return LogResponseBody(responseBodyText);
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, string? requestHeaders, string? requestBody, string? responseBody)
    {
        var errorMessage = "An error occured and logged. Use trace identifier id to find out details";
        var errorDto = new ErrorModel
        {
            ErrorMessage = errorMessage,
            TraceIdentifier = context.TraceIdentifier,
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex is BadHttpRequestException badEx ? badEx.StatusCode : (int)HttpStatusCode.InternalServerError;
        _logger.LogError(ex, _logTemplate,
            context.Request.Method,
            requestBody,
            context.Request.Host,
            requestHeaders,
            responseBody,
            context.Response.StatusCode);
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
    }

    private string LogRequestHeaders(HttpContext httpContext)
    {
        var requestHeaders = new JsonObject();
        foreach (var pair in httpContext.Request.Headers)
        {
            if (_loggingOptions.SanitizeHeaderNames?.Contains(pair.Key.ToLower()) == true)
            {
                requestHeaders.Add(pair.Key, "***");
            }
            else
            {
                requestHeaders.Add(pair.Key, pair.Value.ToString().Replace("\"", ""));
            }
        }
        return requestHeaders.ToJsonString();
    }
    private async ValueTask<string> LogRequestBodyAsync(HttpRequest request, Encoding? encoding = null)
    {
        if (_loggingOptions.LogRequest)
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8, leaveOpen: true);
            string body = await reader.ReadToEndAsync();
            body = body.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            request.Body.Position = 0;

            return body;
        }
        return "";
    }
    private string LogResponseBody(string responseBodyText)
    {
        if (_loggingOptions.SanitizeFieldNames?.Length > 0)
        {
            responseBodyText = LoggingHelper.FilterResponse(responseBodyText, _loggingOptions.SanitizeFieldNames);
        }
        return responseBodyText;
    }


    private class ErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? TraceIdentifier { get; set; }
    }
}
