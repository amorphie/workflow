using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace amorphie.workflow.core.ExceptionHandler;
public class TraceIdMiddleware
{
    private readonly RequestDelegate _next;
 
    public TraceIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }
 
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("traceparent"))
        {
            var traceParent = context.Request.Headers["traceparent"].ToString();
            context.Items["TraceParent"] = traceParent;
        }
 
        await _next(context);
    }
}