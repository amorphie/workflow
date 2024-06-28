using System.Text.Json;
using System.Text.Json.Nodes;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.Consumer;
using amorphie.workflow.redisconsumer.StreamExporters;
using amorphie.workflow.redisconsumer.StreamObjects;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;


namespace amorphie.workflow.redisconsumer.StreamConsumerUsingProto;

internal class JobConsumer : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<JobConsumer>();
    private readonly IInstanceService _instanceService;

    public JobConsumer(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, IInstanceService instanceService) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.JOB;
        this.groupName = ZeebeStreamKeys.Groups.JOB_GROUP;
        ConfigureGroup().Wait();
        _instanceService = instanceService;
    }

    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        string? currentProccessId = "";
        foreach (var process in streamEntries)
        {
            try
            {
                var record = Record.Parser.ParseFrom(process.Values.First().Value);
                var stream = record.Record_.Unpack<JobRecord>();

                if (stream == null)
                {
                    continue;
                }
                currentProccessId = process.Id;
                if (stream.Type == ZeebeVariableKeys.AmorphieWorkflowSetState || stream == null)
                {
                    continue;
                }
                //Take only user tasks
                if ((stream.Metadata.Intent == ZeebeEventKeys.COMPLETED || stream.Metadata.Intent == ZeebeEventKeys.CREATED) && stream.Type == ZeebeVariableKeys.TypeUserTask)
                {

                    await InsertOrUpdateJobBatchAsync(stream, cancellationToken);
                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        var notifyClient = stream.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.NOTIFY_CLIENT).Value?.BoolValue ?? false;
                        var targetState = stream.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.TARGET_STATE).Value?.StringValue;
                        if (notifyClient || !string.IsNullOrEmpty(targetState))
                        {
                            var varsAsJson = JsonSerializer.Deserialize<JsonObject>(stream.Variables.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (varsAsJson == null)
                                continue;

                            var workerBody = JsonObjectConverter.JsonToWorkerBody(varsAsJson);
                            var workerBodyTrxDatas = JsonObjectConverter.GetWorkerBodyTrxData(workerBody);
                            if (notifyClient)
                            {
                                await SendHubMessageAsync(stream, workerBody, workerBodyTrxDatas, cancellationToken);
                            }
                            if (!string.IsNullOrEmpty(targetState))
                            {

                                await _instanceService.ChangeInstanceStateAsync(workerBody.InstanceId, targetState, workerBodyTrxDatas, cancellationToken);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
    }

    private async Task InsertOrUpdateJobBatchAsync(JobRecord stream, CancellationToken cancellationToken)
    {
        var entity = await dbContext.JobBatchs.FirstOrDefaultAsync(s => s.ElementInstanceKey == stream.ElementInstanceKey && s.Key == stream.Metadata.Key, cancellationToken);
        if (entity != null)
        {
            entity.EndTimestamp = stream.Metadata.Timestamp;
            entity.Intent = stream.Metadata.Intent;
            dbContext.JobBatchs.Update(entity);
        }
        else
        {
            //Start event triggered for the first time
            entity = StreamToEntity(stream);
            entity.Key = stream.Metadata.Key;
            entity.Timestamp = stream.Metadata.Timestamp;
            entity.Intent = stream.Metadata.Intent;
            dbContext.JobBatchs.Add(entity);
        }
    }

    private JobBatch StreamToEntity(JobRecord job)
    {
        return new JobBatch
        {
            BpmnProcessId = job.BpmnProcessId,
            ElementInstanceKey = job.ElementInstanceKey,
            ProcessInstanceKey = job.ProcessInstanceKey,
        };
    }
    private async Task SendHubMessageAsync(JobRecord job, WorkerBody workerBody, WorkerBodyTrxDatas workerBodyTrxDatas, CancellationToken cancellationToken)
    {
        if (RegisteredClients.ClientList.TryGetValue(job.ProcessInstanceKey, out WorkerBodyHeaders? bodyHeaders) && bodyHeaders != null)
        {

            var url = job.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.TARGET_STATE).Value?.StringValue ?? "";
            var pageUrl = job.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.PAGE_URL).Value?.StringValue ?? "";
            var viewSource = job.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.VIEW_SOURCE).Value?.StringValue ?? "";
            var pageLanguage = job.CustomHeaders.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Headers.PAGE_LANGUAGE).Value?.StringValue ?? "en-EN";
            // var jobVars = job.Variables;
            // var lastTransition = jobVars.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.LastTransition).Value?.StringValue ?? "";
            // var varInstanceId = new Guid(jobVars.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.InstanceId).Value?.StringValue ?? "");
            // var message = jobVars.Fields.FirstOrDefault(p => p.Key.ToLower() == ZeebeVariableKeys.message).Value?.StringValue ?? "";
            // var errorCode = jobVars.Fields.FirstOrDefault(p => p.Key.ToLower() == ZeebeVariableKeys.errorCode).Value?.StringValue ?? "";

            // var lastTrx = jobVars.Fields.FirstOrDefault(p => p.Key == "TRX" + lastTransition?.DeleteUnAllowedCharecters()).Value?.StructValue;
            // var lastTrxData = lastTrx.Fields.FirstOrDefault(p => p.Key == "Data").Value.StructValue.Fields;
            // var lastTrxDataEntityData = lastTrxData.FirstOrDefault(p => p.Key == "entityData").Value.StructValue;
            // var lastTrxDataTriggeredBy = lastTrxData.FirstOrDefault(p => p.Key == "triggeredBy").Value?.StringValue ?? "";
            // var lastTrxDataAdditionalData = lastTrxData.FirstOrDefault(p => p.Key == "additionalData").Value.StructValue;

            var registeredInstanceGuid = RegisteredClients.ActiveInstanceList.TryGetValue(job.ProcessInstanceKey, out Guid instanceId) ? instanceId : Guid.Empty;
            var hubData = new PostSignalRData(
                UserId: workerBodyTrxDatas.TriggeredBy.GetValueOrDefault(Guid.Empty),
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
                page: new PostPageSignalRData("", "", new MultilanguageText(pageLanguage, pageUrl), 3000),
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
