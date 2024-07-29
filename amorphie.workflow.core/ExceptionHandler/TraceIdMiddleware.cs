using amorphie.workflow.core.Constants;
using Elastic.Apm;
using Elastic.Apm.Api;
using Elastic.Apm.AspNetCore.DiagnosticListener;
using Elastic.Apm.Config;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.Instrumentations.SqlClient;
using Elastic.Apm.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.Configuration;

namespace amorphie.workflow.core.ExceptionHandler;
public static class TraceExtension
{
    /// <summary>
    /// Custom elastic agent setup
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configuration"></param>
    public static void AddTraceMiddleware(this IApplicationBuilder builder, Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        //var logger = builder.ApplicationServices.GetApmLogger();

        //var configReader = new ApmConfiguration(configuration, logger, "test") as IConfigurationReader;

        //var config = new AgentComponents(configurationReader: configReader, logger: logger);

        //var subs = new List<IDiagnosticsSubscriber>(1);

        //    subs.Add(new Elastic.Apm.AspNetCore.DiagnosticListener.AspNetCoreDiagnosticSubscriber());
        // Agent.Setup must be called, even if agent is disabled. This way static public API usage won't implicitly initialize an agent with default values, instead, this will be reused.

        var logger = ApmExtensionsLogger.GetApmLogger(builder.ApplicationServices);
        var creader = new MyCustomConfigReader(configuration, logger, "test") as IConfigurationReader;

        Agent.Setup(new AgentComponents(logger, creader));
        Elastic.Apm.Agent.Subscribe(new HttpDiagnosticsSubscriber(),
                new SqlClientDiagnosticSubscriber(),
                new EfCoreDiagnosticsSubscriber(),
                new AspNetCoreDiagnosticSubscriber()
                //new ElasticsearchDiagnosticsSubscriber(),
                //new GrpcClientDiagnosticSubscriber(),
                //new AzureMessagingServiceBusDiagnosticsSubscriber(),
                //new MicrosoftAzureServiceBusDiagnosticsSubscriber(),
                //new AzureBlobStorageDiagnosticsSubscriber(),
                //new AzureQueueStorageDiagnosticsSubscriber(),
                //new AzureFileShareStorageDiagnosticsSubscriber(),
                //new AzureCosmosDbDiagnosticsSubscriber(),
                //new MongoDbDiagnosticsSubscriber()
                );
    
    }


}



public class TraceIdMiddleware
{
    private readonly RequestDelegate _next;

    public TraceIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // if (context.Request.Headers.ContainsKey("traceparent"))
        // {
        //     var traceParent = context.Request.Headers["traceparent"].ToString();
        //     context.Items["TraceParent"] = traceParent;
        // }

        // if (context.Items.TryGetValue(ElasticApmKeys.TraceParent, out var traceparent) && traceparent != null)
        // {
        //     context.Request.Headers.Append(ElasticApmKeys.TraceParent, traceparent.ToString());

        // }

        var parentTrace = "00-a6b0d7ffe898e0b07cfe266c4022460b-a44fd136767fd962-01";
        context.Request.Headers.Add(ElasticApmKeys.TraceParent, parentTrace);
        //Elastic.Apm.Agent.Subscribe(new Elastic.Apm.AspNetCore.DiagnosticListener.AspNetCoreDiagnosticSubscriber());
        var ct = Elastic.Apm.Agent.Tracer.CurrentTransaction;
        ////var trx = Elastic.Apm.Agent.Tracer.CurrentTransaction;

        ////trx.Context.Request.Headers.TryAdd(ElasticApmKeys.TraceParent, "00-a6b0d7ffe898e0b07cfe266c4022460b-a44fd136767fd962-01");
        //try
        //{
        //    await Elastic.Apm.Agent.Tracer.CaptureTransaction("trx.Name", Elastic.Apm.Api.ApiConstants.TypeRequest, async transaction =>
        //     {
        //         await _next(context);

        //     }, DistributedTracingData.TryDeserializeFromString(parentTrace));
        //}
        //catch (Exception)
        //{

        //    throw;
        //}
        //await _next(context);

        var transaction = Elastic.Apm.Agent.Tracer.StartTransaction("Transaction2", ApiConstants.TypeUnknown,
     DistributedTracingData.TryDeserializeFromString(parentTrace));
        try
        {

            await _next(context);

            //application code that is captured as a transaction
        }
        catch (Exception e)
        {
            transaction.CaptureException(e);
            throw;
        }
        finally
        {
            transaction.End();
        }
        //if (!context.Request.Headers.ContainsKey(ElasticApmKeys.TraceParent))
        //{
        //    context.Request.Headers.Add(ElasticApmKeys.TraceParent, Agent.Tracer.CurrentTransaction.OutgoingDistributedTracingData?.ToString());
        //}

        // var distributedTracingData = traceParent != null ? TraceContext.TryExtractTraceparent(traceParent) : null;

        //         var transaction = Agent.Tracer.StartTransaction("BusinessLogicTransaction", "custom", distributedTracingData);

    }
}