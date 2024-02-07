using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;

namespace amorphie.workflow.core.ExceptionHandler;
public static class GenericExceptionExtension
{
    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

    public static void AddSeriLogWithHttpLogging<TEnricher>(this WebApplicationBuilder builder, List<string> headersToBeLogged) where TEnricher : class, ILogEventEnricher
    {

        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.RequestHeaders.Concat(headersToBeLogged);
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
            logging.CombineLogs = true;
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.TryAddSingleton<ILogEventEnricher, TEnricher>();

        builder.Logging.ClearProviders();

        builder.Host.UseSerilog((_, serviceProvider, loggerConfiguration) =>
        {
            var enricher = serviceProvider.GetRequiredService<ILogEventEnricher>();
            loggerConfiguration
                .ReadFrom.Configuration(builder.Configuration)
                //.Enrich.FromLogContext()
                .Enrich.When(p => p.Exception != null, x => x.With(enricher))
                .Enrich.FromLogContext();
        });
    }
}

