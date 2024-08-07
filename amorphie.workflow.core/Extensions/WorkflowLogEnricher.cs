using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Options;
using Serilog;
using System.Text;
using Microsoft.AspNetCore.Http;
using Elastic.Apm;
using amorphie.workflow.core.Constants;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace amorphie.workflow.core.Extensions;

public class WorkflowLogEnricher : ILogEventEnricher
{
    private const string InstanceId = "InstanceId";
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly string[] wild = { "Authorization", "Password" };
    private readonly IOptionsMonitor<HttpLoggingOptions> _options;

    public WorkflowLogEnricher(IHttpContextAccessor httpContextAccessor, IOptionsMonitor<HttpLoggingOptions> options)
    {
        _httpContextAccessor = httpContextAccessor;
        _options = options;
    }

    private LogEvent _logEvent;
    private ILogEventPropertyFactory _propertyFactory;

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        _logEvent = logEvent;
        _propertyFactory = propertyFactory;

        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is not null)
        {
            //httpContext.Request.Headers.TryAdd(ElasticApmKeys.TraceParent, "00-a6b0d7ffe898e0b07cfe266c4022460b-a44fd136767fd962-01");
            try
            {
                // AddHeaders(httpContext);
                // foreach (var query in httpContext.Request.Query)
                // {
                //     AddPropertyIfAbsent($"query.{query.Key}", query.Value);
                // }
                object? instanceId = null;
                var instanceIdInRoute = httpContext.Request.RouteValues.FirstOrDefault(route => route.Value != null && InstanceId.Equals(route.Key, StringComparison.OrdinalIgnoreCase));
                if (instanceIdInRoute.Value != null)
                {
                    instanceId = instanceIdInRoute.Value;
                }
                if (instanceId == null)
                {
                    httpContext.Items.TryGetValue(InstanceId, out instanceId);
                }
                if (instanceId != null)
                {
                    AddPropertyIfAbsent($"correlation.{InstanceId}", instanceId);
                    //_logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                    //                    "ElasticApmTransactionId", instanceId));
                    //_logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                    //                    "ElasticApmSpanId", instanceId));
                }
                // else if (Agent.IsConfigured)
                // {
                //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                //         "ElasticApmTransactionId", Agent.Tracer.CurrentTransaction.Id));
                //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                //         "ElasticApmTraceId", Agent.Tracer.CurrentTransaction.TraceId));
                //     if (Agent.Tracer.CurrentSpan != null)
                //     {
                //         _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                //             "ElasticApmSpanId", Agent.Tracer.CurrentSpan.Id));
                //     }
                // }
                if (httpContext.Request.Path.HasValue)
                {
                    _logEvent.AddOrUpdateProperty(_propertyFactory.CreateProperty("RequestPath", $"{httpContext.Request.Path.Value}&{httpContext.Request.QueryString}", true));
                }

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TraceIdentifier: {TraceIdentifier}. Log enrichment with httpcontext props failed", httpContext.TraceIdentifier);
            }
        }
        // if (Agent.IsConfigured)
        // {
        //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ElasticApmServiceName", Agent.Config.ServiceName));
        //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ElasticApmServiceVersion", Agent.Config.ServiceVersion));
        //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ElasticApmServiceNodeName", Agent.Config.ServiceNodeName));

        //     if (Agent.Config.GlobalLabels != null)
        //         _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ElasticApmGlobalLabels", Agent.Config.GlobalLabels));

        //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
        //             "ElasticApmTransactionId", Agent.Tracer.CurrentTransaction.Id));
        //     _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
        //         "ElasticApmTraceId", Agent.Tracer.CurrentTransaction.TraceId));
        //     if (Agent.Tracer.CurrentSpan != null)
        //     {
        //         _logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
        //             "ElasticApmSpanId", Agent.Tracer.CurrentSpan.Id));
        //     }
        // }

        AddPropertyIfAbsent("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "None");
        AddPropertyIfAbsent("ApplicationName", Environment.GetEnvironmentVariable("ApplicationName") ?? "None");
    }
    void AddPropertyIfAbsent(string key, object value)
    {
        if (wild.Contains(key))
            value = "******";

        _logEvent.AddPropertyIfAbsent(_propertyFactory.CreateProperty(key, value, true));
    }
    /// <summary>
    /// Gather up all headers into single field
    /// </summary>
    /// <param name="httpContext"></param>
    private void AddHeaders(HttpContext httpContext)
    {
        var builder = new StringBuilder();
        foreach (var header in httpContext.Request.Headers.Where(header => _options.CurrentValue.RequestHeaders.Contains(header.Key)))
        {
            builder.AppendLine(header.Key + ":" + header.Value);
        }
        if (builder.Length > 0)
        {
            AddPropertyIfAbsent("headers", builder.ToString());
        }
    }
}


