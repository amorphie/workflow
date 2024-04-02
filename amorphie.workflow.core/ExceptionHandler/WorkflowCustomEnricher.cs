using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Options;
using amorphie.workflow.core.Constants;

namespace amorphie.workflow.core.ExceptionHandler;

public class WorkflowCustomEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly string[] wild = { "Authorization", "Password" };
    private readonly IOptionsMonitor<HttpLoggingOptions> _options;

    public WorkflowCustomEnricher(IHttpContextAccessor httpContextAccessor, IOptionsMonitor<HttpLoggingOptions> options)
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
            try
            {
                foreach (var header in httpContext.Request.Headers)
                {
                    if (_options.CurrentValue.RequestHeaders.Contains(header.Key))
                    {
                        AddPropertyIfAbsent($"header.{header.Key}", header.Value);
                    }
                }
                foreach (var query in httpContext.Request.Query)
                {
                    AddPropertyIfAbsent($"query.{query.Key}", query.Value);
                }
                var instanceIdInRoute = httpContext.Request.RouteValues.FirstOrDefault(route => route.Value != null && ZeebeVariableKeys.InstanceId.Equals(route.Key, StringComparison.OrdinalIgnoreCase));
                if (instanceIdInRoute.Value != null)
                {
                    AddPropertyIfAbsent($"correlation.{ZeebeVariableKeys.InstanceId}", instanceIdInRoute.Value!);
                }
                if (httpContext.Items.TryGetValue(ZeebeVariableKeys.InstanceId, out var instanceId) && instanceId != null)
                    AddPropertyIfAbsent($"correlation.{ZeebeVariableKeys.InstanceId}", instanceId);
                if (httpContext.Request.Path.HasValue)
                {
                    AddPropertyIfAbsent("RequestPath", httpContext.Request.Path.Value);
                }
            }
            catch (Exception ex)
            {

            }
        }

        AddPropertyIfAbsent("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "None");
        AddPropertyIfAbsent("ApplicationName", Environment.GetEnvironmentVariable("ApplicationName") ?? "None");
    }
    void AddPropertyIfAbsent(string key, object value)
    {
        if (wild.Contains(key))
            value = "******";

        _logEvent.AddPropertyIfAbsent(_propertyFactory.CreateProperty(key, value, true));
    }
}

