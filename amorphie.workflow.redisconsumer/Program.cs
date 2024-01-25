using amorphie.core.Extension;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.redisconsumer;
using amorphie.workflow.redisconsumer.StreamExporters;
using Dapr.Client;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //ConfigurationBuilder setup
        var configurationBuilder = new ConfigurationBuilder();
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
            services.AddHostedService<ExporterWorker>();
            services.AddHostedService<StreamCleanerWorker>();
        })
        .Build();

        host.Run();

    }

}