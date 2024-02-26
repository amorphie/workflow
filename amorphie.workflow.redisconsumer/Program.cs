using amorphie.core.Extension;
using amorphie.workflow.redisconsumer;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        try
        {
            Console.WriteLine("Dapr init ");
            DaprClient daprClient = new DaprClientBuilder().Build();
            Console.WriteLine("program goes to sleep for 5 sec ");
            await Task.Delay(5000);
            Console.WriteLine("program awaked ");
            Console.WriteLine("dapr ... ");

            var confResult = await daprClient.GetSecretAsync("workflow-secretstore", "workflow-secretstore");
            Console.WriteLine("conf result", confResult);


            configurationBuilder.AddInMemoryCollection(confResult);
            var conf = configurationBuilder.Build();
            Console.WriteLine("dapr read completed ");

            var postgreSql = conf.GetValue<string>("workflowdb");
            Console.WriteLine("postgres connstr : ", postgreSql);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Program has throwed an error", ex);
        }
        // //ConfigurationBuilder setup
        // var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        // //configurationBuilder.AddJsonFile($"appsettings.{environment}.json", false, true);
        // await configurationBuilder.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
        // var conf = configurationBuilder.Build();
        // var postgreSql = conf.GetValue<string>("workflowdb");
        // var redisEndPoint = conf.GetValue<string>("redisEndPoints");
        // StateHelper.HubUrl = conf.GetValue<string>("hubUrl");

        // var configurationOptions = new ConfigurationOptions
        // {
        //     EndPoints =
        //     {
        //         redisEndPoint
        //     }
        // };
        // var tokenSource = new CancellationTokenSource();
        // var cancellationToken = tokenSource.Token;
        // Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(conf).CreateLogger();
        // Log.Information($"Amorphie Workflow Redis Consumer Starting : {DateTime.Now}");

        // try
        // {


        //     IHost host = Host.CreateDefaultBuilder(args)
        //     .ConfigureServices(services =>
        //     {

        //         services.AddDaprClient();
        //         services.AddScoped<IDatabase>(cfg =>
        //         {
        //             IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
        //             return multiplexer.GetDatabase();
        //         });
        //         services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
        //         services.AddHostedService<BulkReadWorker>();
        //         //services.AddHostedService<ExporterWorker>();
        //         services.AddHostedService<StreamCleanerWorker>();
        //     })
        //     .UseSerilog(Log.Logger, true)
        //     .Build();

        //     host.Run();
        // }
        // catch (Exception ex)
        // {
        //     Log.Fatal("An unhandled exception occured while starting", ex);
        // }
        // finally
        // {
        //     Log.CloseAndFlush();
        // }

    }

}