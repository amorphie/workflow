using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Security.Principal;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class JobExporter : BaseExporter, IExporter
{

    public JobExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.JOB;
        this.groupName = ZeebeStreamKeys.JOB_GROUP;
        ConfigureGroup().Wait();
    }

    public async Task Attach(CancellationToken cancellationToken)
    {
        // var result = await redisDb.StreamReadGroupAsync(streamName, groupName, this.consumerName, this.readingStrategy);
        var result = await ReadStreamEntryAsync(cancellationToken);

        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<JobStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
                            var hubData = new PostSignalRData(
                                Guid.Empty,
                                Guid.Empty,
                                "message of exporter",
                                Guid.Empty,
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
            var deletedItemsCount = await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());
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
