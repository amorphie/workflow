using amorphie.core.Extension;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.redisconsumer;
using amorphie.workflow.redisconsumer.StreamExporters;
using Dapr.Client;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    private static string hubUrl;
    private static DaprClient daprClient;
    private static async Task Main(string[] args)
    {
        //ConfigurationBuilder setup
        var configurationBuilder = new ConfigurationBuilder();
        await configurationBuilder.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
        var conf = configurationBuilder.Build();
        var postgreSql = conf.GetValue<string>("workflowdb");
        var redisEndPoint = conf.GetValue<string>("redisEndPoints");
        StateHelper.HubUrl = conf.GetValue<string>("hubUrl");

        //DI setup
        IServiceCollection services = new ServiceCollection();
        services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
        var serviceProvider = services.BuildServiceProvider();


        var dbContext = serviceProvider.GetRequiredService<WorkflowDBContext>();

        var configurationOptions = new ConfigurationOptions
        {
            EndPoints =
            {
                redisEndPoint
            }
        };
        var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
        var redisDb = connectionMultiplexer.GetDatabase();
        var tokenSource = new CancellationTokenSource();
        var cancellationToken = tokenSource.Token;

        string readingStrategy = ">";
        var consumerName = Environment.MachineName + "1"; //it is needed for consumer group, 

        //await StateHelper.CallStateManager("","default",cancellationToken);



        var streamCleaner = new StreamCleaner();
        var tasks = new List<Task>
        {

            Task.Run(() => ActivateExporters(dbContext, redisDb, consumerName, readingStrategy, cancellationToken)),
            Task.Run(()=>streamCleaner.TrimNotAttachedStream(connectionMultiplexer, 100, cancellationToken)),

        };
        Task tasksResult;
        try
        {
            tasksResult = await Task.WhenAny(tasks);

        }
        catch (System.Exception)
        {

            throw;
        }
        Console.WriteLine(tasksResult?.Exception?.Message);
        Console.WriteLine(tasksResult?.Exception?.InnerException?.Message);

        //await ActivateExporters(dbContext, redisDb, consumerName, readingStrategy, cancellationToken);

        tokenSource.Cancel();


    }

    public static async Task ActivateExporters(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy, CancellationToken cancellationToken)
    {
        var deploymentExporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName, readingStrategy);
        var incidentExporter = new IncidentExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageExporter = new MessageExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageStartEventExporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageSubscriptionExporter = new MessageSubscriptionExporter(dbContext, redisDb, consumerName, readingStrategy);
        var processInstanceExporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName, readingStrategy);
        var variableExporter = new VariableExporter(dbContext, redisDb, consumerName, readingStrategy);
        var jobExporter = new JobExporter(dbContext, redisDb, consumerName, readingStrategy);

        while (!cancellationToken.IsCancellationRequested)
        {
            await deploymentExporter.Attach(cancellationToken);
            await incidentExporter.Attach(cancellationToken);
            await messageStartEventExporter.Attach(cancellationToken);
            await messageSubscriptionExporter.Attach(cancellationToken);
            await messageExporter.Attach(cancellationToken);
            await processInstanceExporter.Attach(cancellationToken);
            await variableExporter.Attach(cancellationToken);
            await jobExporter.Attach(cancellationToken);
            await Task.Delay(1000);

        }
    }

}