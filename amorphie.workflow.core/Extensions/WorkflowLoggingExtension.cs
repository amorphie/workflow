using amorphie.workflow.core.Logging;
using Elastic.Apm.SerilogEnricher;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
namespace amorphie.workflow.core.Extensions;
public static class WorkflowLoggingExtension
{
    public static void WfUseLoggingHandlerMiddlewares(this WebApplication app)
    {
        //app.UseMiddleware<ExceptionHandlerMiddleware>();
        //Request and Response Logging
        //app.UseHttpLogging();
        var loggingOptions = new LoggingOptions();
        var loggingSection =app.Configuration.GetSection(LoggingOptions.Logging);
        loggingSection.Bind(loggingOptions);
        var sanitizeFieldNames = loggingSection.GetValue<string>(nameof(LoggingOptions.SanitizeFieldNames));
        loggingOptions.SanitizeFieldNames = sanitizeFieldNames?.Split(',');
        var sanitizeHeaderNames = loggingSection.GetValue<string>(nameof(LoggingOptions.SanitizeHeaderNames));
        loggingOptions.SanitizeHeaderNames = sanitizeHeaderNames?.Split(',');
        var ignorePaths = loggingSection.GetValue<string>(nameof(LoggingOptions.IgnorePaths));
        loggingOptions.IgnorePaths = ignorePaths?.Split(',');

        app.UseMiddleware<LoggingMiddleware>(loggingOptions);
        //app.UseMiddleware<LoggingMiddlewareAsJson>(loggingOptions);
    }

    public static void WfAddSeriLogWithHttpLogging<TEnricher>(this WebApplicationBuilder builder) where TEnricher : class, ILogEventEnricher
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.TryAddSingleton<ILogEventEnricher, TEnricher>();

        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((_, serviceProvider, loggerConfiguration) =>
        {
            var enricher = serviceProvider.GetRequiredService<ILogEventEnricher>();
            loggerConfiguration
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.With(enricher)
                .Enrich.WithElasticApmCorrelationInfo()
                ;
        });
    }
}



