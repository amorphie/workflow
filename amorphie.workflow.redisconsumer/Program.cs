using amorphie.core.Extension;
using amorphie.workflow.redisconsumer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;


internal class Program
{
    private static async Task Main(string[] args)
    {

        //ConfigurationBuilder setup
        var configurationBuilder = new ConfigurationBuilder();
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //configurationBuilder.AddJsonFile($"appsettings.{environment}.json", false, true);
        await configurationBuilder.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
        var conf = configurationBuilder.Build();
        var postgreSql = conf.GetValue<string>("workflowdb");
        var redisEndPoint = conf.GetValue<string>("redisEndPoints");
        StateHelper.HubUrl = conf.GetValue<string>("hubUrl");

        var configurationOptions = new ConfigurationOptions
        {
            EndPoints =
            {
                redisEndPoint
            }
        };
        var tokenSource = new CancellationTokenSource();
        var cancellationToken = tokenSource.Token;
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(conf).CreateLogger();
        Log.Information($"Amorphie Workflow Redis Consumer Starting : {DateTime.Now}");

        try
        {


            IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {

                services.AddDaprClient();
                services.AddScoped<IDatabase>(cfg =>
                {
                    IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
                    return multiplexer.GetDatabase();
                });
                services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
                services.AddHostedService<BulkReadWorker>();
                //services.AddHostedService<ExporterWorker>();
                services.AddHostedService<StreamCleanerWorker>();
            })
            .UseSerilog(Log.Logger, true)
            .Build();

            host.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal("An unhandled exception occured while starting", ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }

}