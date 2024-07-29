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

    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? requestInfo = null;
        string? responseInfo = null;
        Stream? originalResponseBody = null;
        using var newResponseBody = new MemoryStream();
        try
        {
            requestInfo = await LogRequest(context);

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
            responseInfo = LogResponse(context, responseBodyText);

            _logger.LogInformation("Request : {Request}, Response : {Response}", requestInfo, responseInfo);

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

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, string? requestInfo, string? responseInfo)
    {
        var errorMessage = $"An error occured and logged. Use trace identifier id to find out details";
        var errorDto = new ErrorModel
        {
            ErrorMessage = errorMessage,
            TraceIdentifier = context.TraceIdentifier,
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex is BadHttpRequestException badEx ? badEx.StatusCode : (int)HttpStatusCode.InternalServerError;
        _logger.LogError(ex, "TraceIdentifier : {TraceIdentifier}. Exception: {ex}, Request : {Request}, Response : {Response}", context.TraceIdentifier, ex, requestInfo, responseInfo);
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
    }

    private async Task<string> LogRequest(HttpContext context)
    {
        var request = context.Request;
        var requestLog = new StringBuilder();
        //requestLog.AppendLine("Incoming Request:");
        requestLog.AppendLine($"HTTP {request.Method} {request.Path}");
        requestLog.AppendLine($"Host: {request.Host}");
        requestLog.AppendLine(await RequestAsTextAsync(context));
        requestLog.AppendLine($"Content-Type: {request.ContentType}");
        requestLog.AppendLine($"Content-Length: {request.ContentLength}");
        return requestLog.ToString();
    }

    private static async Task<string> RequestAsTextAsync(HttpContext httpContext)
    {
        string rawRequestBody = await GetRawBodyAsync(httpContext.Request);

        IEnumerable<string> headerLine = httpContext.Request.Headers.Where(h => h.Key != "Authentication").Select(pair => $"{pair.Key} => {string.Join("|", pair.Value.ToList())}");
        string headerText = string.Join(Environment.NewLine, headerLine);

        string message =
          $"Request: {httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}{Environment.NewLine}" +
          $"Headers: {Environment.NewLine}{headerText}{Environment.NewLine}" +
          $"Content : {Environment.NewLine}{rawRequestBody}";

        return message;
    }
    private static async Task<string> GetRawBodyAsync(HttpRequest request, Encoding? encoding = null)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8, leaveOpen: true);
        string body = await reader.ReadToEndAsync().ConfigureAwait(false);
        request.Body.Position = 0;

        return body;
    }


    private string LogResponse(HttpContext context, string responseBodyText)
    {
        var response = context.Response;
        var responseLog = new StringBuilder();
        //responseLog.AppendLine("Outgoing Response:");
        responseLog.AppendLine($"HTTP {response.StatusCode}");
        responseLog.AppendLine($"Content-Type: {response.ContentType}");
        responseLog.AppendLine($"Content-Length: {response.ContentLength}");
        responseLog.AppendLine($"Response-Body: {responseBodyText}");
        return responseLog.ToString();
    }
    private class ErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? TraceIdentifier { get; set; }
    }
}