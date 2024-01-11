using Microsoft.AspNetCore.Http;
namespace amorphie.workflow.service.Zeebe;
    public class ZeebeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string bindingGateway;
        public ZeebeExceptionMiddleware(RequestDelegate next, string gateway)
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
            if (ex is ZeebeBussinesException bussinesException)
            {
                await zeebeCommandService.ThrowError(bindingGateway, jobKey, bussinesException.ErrorCode, bussinesException.ErrorMessage);
            }
            else
            {
                await zeebeCommandService.ThrowError(bindingGateway, jobKey, "NonBusinessError", ex.Message);
            }
            await _next(httpContext);
        }
    }
