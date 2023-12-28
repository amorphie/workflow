using amorphie.workflow.redisconsumer.StreamExporters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string postgreSql = "Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres;Include Error Detail=true;";
        IServiceCollection services = new ServiceCollection();
        services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<WorkflowDBContext>();

        //ToDo: Impelement Dapr
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints =
            {
                "localhost:6379"
            }
        };
        var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
        var redisDb = connectionMultiplexer.GetDatabase();
        var tokenSource = new CancellationTokenSource();
        var cancellationToken = tokenSource.Token;

        var consumerName = Environment.MachineName; //it is neede for consumer group, 
        var messageStartEventExporter = new MessageStartEventSubscriptionExporter(dbContext, consumerName);
        await messageStartEventExporter.Attach(redisDb, cancellationToken);

        Console.ReadLine();

        



    }
}