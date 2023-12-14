using Microsoft.AspNetCore.Builder;

namespace amorphie.workflow.service.Zeebe
{
    public static class ZeebeBusinessExceptionExtension
    {
        public static void AddZeebeWorkerMiddleware(this IApplicationBuilder app, string zeebeGateway)
        {
            app.UseMiddleware<ZeebeWorkerMiddleware>(zeebeGateway);
        }
    }
}
