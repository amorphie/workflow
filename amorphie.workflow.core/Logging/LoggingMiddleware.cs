using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;

namespace amorphie.workflow.core.Logging;

public class LoggingMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly LoggingOptions _loggingOptions;
    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        _loggingOptions = loggingOptions;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stream? originalResponseBody = null;
        string? requestInfo = null;
        string? responseInfo = null;
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


    private async Task<string?> InvokeInternalAsync(HttpContext context, Stream originalResponseBody)
    {
        string? responseInfo = null;
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

        responseInfo = $"{LogResponseHeaders(context)} {Environment.NewLine} {LogResponseBody(responseBodyText)}";
        return responseInfo;
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, string? requestInfo, string? responseInfo)
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

    private async Task<string> LogRequest(HttpContext context)
    {
        var request = context.Request;
        var requestLog = new StringBuilder();
        requestLog.AppendLine($"HTTP {request.Method} {request.Path}");
        requestLog.AppendLine($"Host: {request.Host}");
        requestLog.AppendLine(await RequestAsTextAsync(context));
        requestLog.AppendLine($"Content-Type: {request.ContentType}");
        return requestLog.ToString();
    }

    private async Task<string> RequestAsTextAsync(HttpContext httpContext)
    {
        string headerText = RequestHeadersAsText(httpContext);
        var requestLog = new StringBuilder();
        requestLog.AppendLine($"Request: {httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}{Environment.NewLine}");
        requestLog.AppendLine($"Headers: {Environment.NewLine}{headerText}{Environment.NewLine}");
        if (_loggingOptions.LogRequest)
        {
            string rawRequestBody = await GetRawBodyAsync(httpContext.Request);
            requestLog.AppendLine($"Content : {Environment.NewLine}{rawRequestBody}");
        }
        return requestLog.ToString();
    }

    private string RequestHeadersAsText(HttpContext httpContext)
    {
        IEnumerable<string> headerLine = httpContext.Request.Headers
            .Select(
            pair =>
            {
                if (_loggingOptions.SanitizeHeaderNames?.Contains(pair.Key.ToLower()) == true)
                {
                    return $"{pair.Key} => ***";
                }
                else
                {
                    return $"{pair.Key} => {string.Join("|", pair.Value.ToList()).Replace("\"", "")}";
                }
            });
        return string.Join(Environment.NewLine, headerLine);
    }

    private async Task<string> GetRawBodyAsync(HttpRequest request, Encoding? encoding = null)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8, leaveOpen: true);
        string body = await reader.ReadToEndAsync().ConfigureAwait(false);
        request.Body.Position = 0;

        return body;
    }


    private string LogResponseHeaders(HttpContext context)
    {
        var response = context.Response;
        var responseLog = new StringBuilder();
        responseLog.AppendLine($"HTTP {response.StatusCode}");
        responseLog.AppendLine($"Content-Type: {response.ContentType}");
        return responseLog.ToString();
    }

    private string LogResponseBody(string responseBodyText)
    {
        if (_loggingOptions.SanitizeFieldNames != null && _loggingOptions.SanitizeFieldNames.Length > 0)
        {
            responseBodyText = LoggingHelper.FilterResponse(responseBodyText, _loggingOptions.SanitizeFieldNames);
        }
        return $"Response Body : {responseBodyText}";
    }


    private class ErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? TraceIdentifier { get; set; }
    }
}