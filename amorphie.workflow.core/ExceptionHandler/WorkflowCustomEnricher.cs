using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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

    public async void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
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
                foreach (var route in httpContext.Request.RouteValues.Where(p => p.Value != null))
                {
                    AddPropertyIfAbsent($"route.{route.Key}", route.Value!);
                    if (ZeebeVariableKeys.InstanceId.Equals(route.Key, StringComparison.OrdinalIgnoreCase))
                        AddPropertyIfAbsent($"correlation.{ZeebeVariableKeys.InstanceId}", route.Value!);

                }
                if (httpContext.Items.TryGetValue(ZeebeVariableKeys.InstanceId, out var instanceId))
                    AddPropertyIfAbsent($"correlation.{ZeebeVariableKeys.InstanceId}", instanceId);

                var request = httpContext.Request;
                var stream = request.Body;// At the begining it holding original request stream                    
                var originalReader = new StreamReader(stream);
                var originalContent = await originalReader.ReadToEndAsync();

                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(originalContent);
                if (jsonObject != null)
                    RecursiveJsonLoop(jsonObject, "body");
            }
            catch (Exception ex)
            {

            }
        }

        AddPropertyIfAbsent("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        AddPropertyIfAbsent("ApplicationName", Environment.GetEnvironmentVariable("ApplicationName"));
    }
    void RecursiveJsonLoop(JObject jsonObject, string currentPath)
    {
        if (jsonObject == null)
            return;

        foreach (var property in jsonObject.Properties())
        {
            string newPath = currentPath == "" ? property.Name : $"{currentPath}.{property.Name}";

            if (property.Value.Type == JTokenType.Object)
            {
                RecursiveJsonLoop((JObject)property.Value, newPath);
            }
            else if (property.Value.Type == JTokenType.Array)
            {
                for (int i = 0; i < ((JArray)property.Value).Count; i++)
                {
                    RecursiveJsonLoop((JObject)((JArray)property.Value)[i], $"{newPath}[{i}]");
                }
            }
            else
            {
                AddPropertyIfAbsent($"{newPath}", property.Value.ToString());
            }
        }
    }

    void AddPropertyIfAbsent(string key, object value)
    {
        if (wild.Contains(key))
            value = "******";

        _logEvent.AddPropertyIfAbsent(_propertyFactory.CreateProperty(key, value, true));
    }
}

