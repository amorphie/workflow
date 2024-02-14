using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class JobExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<JobExporter>();

    public JobExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.JOB;
        this.groupName = ZeebeStreamKeys.JOB_GROUP;
        ConfigureGroup().Wait();
    }

    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        try
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in streamEntries)
            {
                var stream = Deserialize<JobStream>(process);

                if (stream == null)
                {
                    continue;
                }

                if (stream.Intent == ZeebeEventKeys.COMPLETED || stream.Intent == ZeebeEventKeys.CREATED)
                {
                    var entity = dbContext.Jobs.FirstOrDefault(s => s.Key == stream.Value.ElementInstanceKey);

                    if (entity != null)
                    {
                        //entity.Intent = stream.Intent;
                        //entity.ModifiedAt = DateTime.UtcNow;
                        entity.EndTimestamp = stream.Timestamp;
                        entity.Intent = stream.Intent;
                        dbContext.Jobs.Update(entity);
                    }
                    else
                    {
                        //Start event triggered for the first time
                        entity = StreamToEntity(stream);
                        dbContext.Jobs.Add(entity);
                    }

                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        messageToBeDeleted.Add(process.Id);
                        Boolean.TryParse(stream.Value.CustomHeaders["notifyClient"]?.ToString(), out bool notifyClient);
                        var elementType = stream.Value.Type;
                        if (notifyClient)
                        {
                            var instanceGuid = RegisteredClients.ActiveInstanceList.TryGetValue(stream.Value.ProcessInstanceKey, out Guid instanceId) ? instanceId : Guid.Empty;
                            var hubData = new PostSignalRData(
                                Guid.Empty,
                                instanceGuid,
                                "message from exporter",
                                instanceGuid,
                                stream.Value.ElementId ?? "",
                                "",
                                DateTime.Now,
                                stream.Intent,
                                "",
                                amorphie.core.Enums.StatusType.New,
                                new PostPageSignalRData("", "", new MultilanguageText("", ""), 1000),
                                message: elementType,
                                "",
                                "",
                                workflowName: stream.Value.BpmnProcessId ?? "",
                                "",
                                false,
                                buttonType: ""
                            );

                            if (RegisteredClients.ClientList.TryGetValue(stream.Value.ProcessInstanceKey, out WorkerBodyHeaders? bodyHeaders) && bodyHeaders != null)
                            {

                                await StateHelper.SendHubMessage(hubData, "eventInfo", "",
                                bodyHeaders.XDeviceId,
                                bodyHeaders.XTokenId,
                                bodyHeaders.ACustomer,
                                cancellationToken);
                            }
                        }

                    }
                }
                else
                {
                    //delete the messages which have other Intent's
                    messageToBeDeleted.Add(process.Id);
                }

            }
            var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Error($"{e}");
            throw;
        }
    }

    private Job StreamToEntity(JobStream stream)
    {
        return new Job
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Value.ElementInstanceKey,
            Timestamp = stream.Timestamp,
            ElementType = stream.Value.Type,
            Intent = stream.Intent,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey
        };
    }
}
