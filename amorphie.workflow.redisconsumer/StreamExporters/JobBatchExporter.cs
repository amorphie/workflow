using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;


namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class JobBatchExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<JobExporter>();
    private readonly IInstanceService _instanceService;

    public JobBatchExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, IInstanceService instanceService) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.JOB;
        this.groupName = ZeebeStreamKeys.Groups.JOB_GROUP;
        ConfigureGroup().Wait();
        _instanceService = instanceService;
    }

    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        var messageToBeDeleted = new List<RedisValue>();
        string? currentProccessId = "";
        foreach (var process in streamEntries)
        {
            try
            {
                var stream = Deserialize<JobBatchStream>(process);
                if (stream == null)
                {
                    continue;
                }
                currentProccessId = process.Id;
                if (stream.Value.Type == "amorphie-workflow-set-state" || stream.Value.Jobs == null)
                {
                    messageToBeDeleted.Add(process.Id);
                    continue;
                }
                if (stream.Intent == ZeebeEventKeys.ACTIVATED)
                {
                    foreach (var job in stream.Value.Jobs)
                    {
                        if (job.Variables == null)
                        {                           
                            continue;
                        }
                        await InsertOrUpdateJobBatchAsync(stream, job, cancellationToken);
                        var savingResult = await dbContext.SaveChangesAsync();
                        if (savingResult > 0)
                        {
                            messageToBeDeleted.Add(process.Id);
                            Boolean.TryParse(job.CustomHeaders["NOTIFY_CLIENT"]?.ToString(), out bool notifyClient);
                            string? targetState = job.CustomHeaders["TARGET_STATE"]?.ToString();
                            if (notifyClient || !string.IsNullOrEmpty(targetState))
                            {
                                var workerBody = JsonObjectConverter.JsonToWorkerBody(job.Variables);
                                var workerBodyTrxDatas = JsonObjectConverter.GetWorkerBodyTrxData(workerBody);
                                if (notifyClient)
                                {
                                    await SendHubMessageAsync(job, workerBody, workerBodyTrxDatas, cancellationToken);
                                }
                                if (!string.IsNullOrEmpty(targetState))
                                {
                                    await _instanceService.ChangeInstanceStateAsync(workerBody.InstanceId, targetState, workerBodyTrxDatas, cancellationToken);
                                }
                            }
                        }
                    }
                    messageToBeDeleted.Add(process.Id);
                }
                else
                {
                    //delete the messages which have other Intent's
                    messageToBeDeleted.Add(process.Id);
                }
            }
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
        var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
    }
    private async Task InsertOrUpdateJobBatchAsync(JobBatchStream stream, JobBatchJobs job, CancellationToken cancellationToken)
    {
        var entity = await dbContext.JobBatchs.FirstOrDefaultAsync(s => s.ElementInstanceKey == job.ElementInstanceKey && s.Key == stream.Key, cancellationToken);
        if (entity != null)
        {
            entity.EndTimestamp = stream.Timestamp;
            entity.Intent = stream.Intent;
            dbContext.JobBatchs.Update(entity);
        }
        else
        {
            //Start event triggered for the first time
            entity = StreamToEntity(job);
            entity.Key = stream.Key;
            entity.Timestamp = stream.Timestamp;
            entity.Intent = stream.Intent;
            dbContext.JobBatchs.Add(entity);
        }
    }

    private JobBatch StreamToEntity(JobBatchJobs job)
    {
        return new JobBatch
        {
            BpmnProcessId = job.BpmnProcessId,
            ElementInstanceKey = job.ElementInstanceKey,
            ProcessInstanceKey = job.ProcessInstanceKey,
        };
    }

    private async Task SendHubMessageAsync(JobBatchJobs job, WorkerBody workerBody, WorkerBodyTrxDatas workerBodyTrxDatas, CancellationToken cancellationToken)
    {
        if (RegisteredClients.ClientList.TryGetValue(job.ProcessInstanceKey, out WorkerBodyHeaders? bodyHeaders) && bodyHeaders != null)
        {
            var url = job.CustomHeaders["url"];
            var pageUrl = job.CustomHeaders["PAGE_URL"];
            var viewSource = job.CustomHeaders["VIEW_SOURCE"]?.ToString() ?? "";
            //headers that come from instance trigger
            var headers = job.Variables["Headers"];
            //Headers that mentioned in bpmn
            var customHeaders = job.CustomHeaders;

            var registeredInstanceGuid = RegisteredClients.ActiveInstanceList.TryGetValue(job.ProcessInstanceKey, out Guid instanceId) ? instanceId : Guid.Empty;
            var hubData = new PostSignalRData(
                UserId: workerBodyTrxDatas.TriggeredBy,
                recordId: workerBody.InstanceId,
                eventInfo: "message from exporter",
                instanceId: workerBody.InstanceId,
                entityName: job.ElementId ?? "",
                data: workerBodyTrxDatas.Data!.EntityData,
                time: DateTime.UtcNow,
                state: workerBody.LastTransition,
                transition: workerBody.LastTransition,
                stateTransitions: null,
                baseStatus: amorphie.core.Enums.StatusType.New,
                page: new PostPageSignalRData("", "", new MultilanguageText("", ""), 1234),
                message: workerBody.Message,
                errorCode: workerBody.ErrorCode,
                additionalData: workerBodyTrxDatas.Data!.AdditionalData,
                workflowName: job.BpmnProcessId ?? "",
                viewSource: viewSource,
                requireData: false,
                buttonType: ""
            );
            await StateHelper.SendHubMessage(hubData, "eventInfo", "", bodyHeaders, cancellationToken);
        }
    }
}
