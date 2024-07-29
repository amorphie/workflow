using Elastic.Apm.Config;
using Elastic.Apm.Helpers;
using Elastic.Apm.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace amorphie.workflow.core.ExceptionHandler
{
    internal class MyCustomConfigReader : FallbackToEnvironmentConfigurationBase
    {
        private const string ThisClassName = nameof(MyCustomConfigReader);

        public MyCustomConfigReader(Microsoft.Extensions.Configuration.IConfiguration configuration, Elastic.Apm.Logging.IApmLogger logger, string defaultEnvironmentName)
            : base(logger,
                new ConfigurationDefaults { EnvironmentName = defaultEnvironmentName, DebugName = ThisClassName },
                new ConfigurationKeyValueProvider(configuration)) =>
            configuration.GetSection("ElasticApm")
                ?
                .GetReloadToken()
                .RegisterChangeCallback(ChangeCallback, configuration.GetSection("ElasticApm"));

        private void ChangeCallback(object obj)
        {
            if (obj is not IConfigurationSection)
                return;

            var newLogLevel = ParseLogLevel(Lookup(ConfigurationOption.LogLevel));
            if (LogLevel == newLogLevel)
                return;
            LogLevel = newLogLevel;
        }
    }

    internal class ConfigurationKeyValueProvider : IConfigurationKeyValueProvider
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public ConfigurationKeyValueProvider(Microsoft.Extensions.Configuration.IConfiguration configuration) => _configuration = configuration;

        public string Description => nameof(ConfigurationKeyValueProvider);

        public ApplicationKeyValue Read(ConfigurationOption option)
        {
            var key = option.ToConfigKey();
            var value = _configuration[key];
            return value != null ? new ApplicationKeyValue(option, value, Description) : null;
        }
    }
    internal sealed class ApmExtensionsLogger : IApmLogger
    {
        private readonly ILogger _logger;

        public ApmExtensionsLogger(ILoggerFactory loggerFactory) => _logger = loggerFactory?.CreateLogger("Elastic.Apm") ?? throw new ArgumentNullException(nameof(loggerFactory));

        public bool IsEnabled(Elastic.Apm.Logging.LogLevel level) => _logger.IsEnabled(Convert(level));

        public void Log<TState>(Elastic.Apm.Logging.LogLevel level, TState state, Exception e, Func<TState, Exception, string> formatter) =>
            _logger.Log(Convert(level), new EventId(), state, e, formatter);

        private static Microsoft.Extensions.Logging.LogLevel Convert(Elastic.Apm.Logging.LogLevel logLevel) =>
            logLevel switch
            {
                Elastic.Apm.Logging.LogLevel.Trace => Microsoft.Extensions.Logging.LogLevel.Trace,
                Elastic.Apm.Logging.LogLevel.Debug => Microsoft.Extensions.Logging.LogLevel.Debug,
                Elastic.Apm.Logging.LogLevel.Information => Microsoft.Extensions.Logging.LogLevel.Information,
                Elastic.Apm.Logging.LogLevel.Warning => Microsoft.Extensions.Logging.LogLevel.Warning,
                Elastic.Apm.Logging.LogLevel.Error => Microsoft.Extensions.Logging.LogLevel.Error,
                Elastic.Apm.Logging.LogLevel.Critical => Microsoft.Extensions.Logging.LogLevel.Critical,
                _ => Microsoft.Extensions.Logging.LogLevel.None,
            };

        internal static IApmLogger GetApmLogger(IServiceProvider serviceProvider) =>
            serviceProvider.GetService(typeof(ILoggerFactory)) is ILoggerFactory loggerFactory
                ? new ApmExtensionsLogger(loggerFactory)
                : throw new Exception("");
    }
}
