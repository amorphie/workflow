using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace amorphie.workflow.service.SchemaValidation;
public static class SchemaValidationExtension
{
    public static void AddSchemaValidationService(this WebApplicationBuilder builder)
    {
        var clientBasePath = builder.Configuration.GetSection("HttpClient")["SchemaValidationService"];
        if (clientBasePath is null)
            throw new Exception("SchemaValidationService api path not found under the HttpClient section");

        builder.Services.AddHttpClient("schemaValidationService", conf =>
        {
            conf.BaseAddress = new Uri(clientBasePath);

        })
        .ConfigurePrimaryHttpMessageHandler((c) => new HttpClientHandler()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    }
        });
    }

    public static void UseSchemaValidationMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<SchemaValdationMiddleware>();

    }

}
