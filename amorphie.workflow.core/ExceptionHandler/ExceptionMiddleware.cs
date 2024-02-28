using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace amorphie.workflow.core.ExceptionHandler;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ILogger Logger = Log.ForContext(MethodBase.GetCurrentMethod()?.DeclaringType);
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        //var errorMessage = ex.Message + " " + ex.InnerException?.Message + " Current Stack " + ex.StackTrace + " All Exception" + ex.ToString();
        var errorMessage = $"An error occured and logged with \"{httpContext.TraceIdentifier}\" trace identifier id";

        httpContext.Response.ContentType = "application/json";
        if (ex is BadHttpRequestException badEx)
        {
            httpContext.Response.StatusCode = badEx.StatusCode;
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        Logger.Error($"{ex}");
        await httpContext.Response.WriteAsync(errorMessage);

    }
}