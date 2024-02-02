using System.Net;
using amorphie.core.Enums;
using Microsoft.AspNetCore.Http;

namespace amorphie.workflow.service.Zeebe
{
    public class ZeebeWorkerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string bindingGateway;
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

            var throwResult = await zeebeCommandService.ThrowError(bindingGateway, jobKey, errorCode, errorMessage);
            if (throwResult.Status == Status.Success.ToString())
            {
                await _next(httpContext);
            }
            else
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //var now = DateTime.UtcNow;
                //Log.Error($"{now.ToString("HH:mm:ss")} : {ex}");
                await httpContext.Response.WriteAsync(throwResult?.Message.ToString() ?? "");
            }
        }
    }
}