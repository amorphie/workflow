using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using amorphie.core.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace amorphie.workflow.service.Zeebe
{
    public class ZeebeWorkerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string bindingGateway;
        private static readonly ILogger Logger = Log.ForContext(MethodBase.GetCurrentMethod()?.DeclaringType);

        public ZeebeWorkerMiddleware(RequestDelegate next, string gateway)
        {
            _next = next;
            bindingGateway = gateway;
        }

        public async Task InvokeAsync(HttpContext httpContext, IZeebeCommandService zeebeCommandService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, zeebeCommandService, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, IZeebeCommandService zeebeCommandService, Exception ex)
        {
            var jobKey = Convert.ToInt64(httpContext.Request.Headers["X-Zeebe-Job-Key"]);
            var processInstanceKey = Convert.ToInt64(httpContext.Request.Headers["X-Zeebe-Process-Instance-Key"]);
            string errorCode, errorMessage;

            if (ex is ZeebeBussinesException bussinesException)
            {
                errorCode = bussinesException.ErrorCode;
                errorMessage = bussinesException.ErrorMessage;
            }
            else
            {
                errorCode = "NonBusinessError";
                errorMessage = ex.Message + " " + ex.InnerException?.Message;
            }
            Logger.Error(ex,"{ErrorCode} : {ErrorMessage}", errorCode ,errorCode);

            var throwResult = await zeebeCommandService.ThrowError(bindingGateway, processInstanceKey, jobKey, errorCode, errorMessage);
            if (throwResult.Status == Status.Success.ToString())
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.AlreadyReported;
                await httpContext.Response.WriteAsync("Worker throwed Zeebe Error");
            }
            else
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync(throwResult?.Message.ToString() ?? "");
            }
        }
    }
}