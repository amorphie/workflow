using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class ProcessInstanceExporter : BaseExporter, IExporter
{
    public ProcessInstanceExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.PROCESS_INSTANCE;
        this.groupName = ZeebeStreamKeys.PROCESS_INSTANCE_GROUP;
        ConfigureGroup().Wait();
    }
    public async Task Attach(CancellationToken cancellationToken)
    {

        var result = await ReadStreamEntryAsync(cancellationToken);
        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<ProcessInstanceStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    continue;
                }
                //Do not log these elements
                if (stream.Value.BpmnElementType == ZeebeElementTypeKeys.SEQUENCE_FLOW || stream.Value.BpmnElementType == ZeebeElementTypeKeys.EXCLUSIVE_GATEWAY)
                {
                    messageToBeDeleted.Add(process.Id);
                    continue;
                }

                var entity = dbContext.ProcessInstances.FirstOrDefault(p => p.Key == stream.Key);
                if (entity != null)
                {
                    entity.Intent = stream.Intent!;
                    entity.EndTimestamp = stream.Timestamp;
                    dbContext.ProcessInstances.Update(entity);
                }
                else
                {
                    entity = StreamToEntity(stream);
                    dbContext.ProcessInstances.Add(entity);
                }
                //if workflow is at edge of the TRANSITION (amorphie definition represented with INTERMEDIATE_CATCH_EVENT in zeebe) and not called yet
                if (stream.Value.BpmnElementType == ZeebeElementTypeKeys.INTERMEDIATE_CATCH_EVENT && stream.Intent == ZeebeEventKeys.ELEMENT_ACTIVATED)
                {

                }
                //if workflow is done, eventhough flow ends (flow maybe a subprocess), the main process may not end
                //thus check parentprocess key entity.ParentProcessInstanceKey == -1 means it is parent
                if (stream.Value.BpmnElementType == ZeebeElementTypeKeys.END_EVENT && stream.Intent == ZeebeEventKeys.ELEMENT_COMPLETED && entity.ParentProcessInstanceKey == -1)
                {
                    RegisteredClients.ClientList.Remove(entity.ProcessInstanceKey);
                    RegisteredClients.ActiveInstanceList.Remove(entity.ProcessInstanceKey);

                }
                var savingResult = await dbContext.SaveChangesAsync();
                if (savingResult > 0)
                {
                    messageToBeDeleted.Add(process.Id);
                }
            }
           var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
        }
    }
    private ProcessInstance StreamToEntity(ProcessInstanceStream stream)
    {
        return new ProcessInstance
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Timestamp = stream.Timestamp,
            ValueType = stream.ValueType,
            BrokerVersion = stream.BrokerVersion,
            SourceRecordPosition = stream.SourceRecordPosition,
            Intent = stream.Intent,

            Position = stream.Position,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey,
            ProcessDefinitionKey = stream.Value.ProcessDefinitionKey,
            RecordType = stream.RecordType,

            RejectionType = stream.RejectionType,
            RejectionReason = stream.RejectionReason,
            BpmnElementType = stream.Value.BpmnElementType,
            BpmnEventType = stream.Value.BpmnEventType,
            ElementId = stream.Value.ElementId,
            FlowScopeKey = stream.Value.FlowScopeKey,
            ParentElementInstanceKey = stream.Value.ParentElementInstanceKey,
            ParentProcessInstanceKey = stream.Value.ParentProcessInstanceKey,
            PartitionId = stream.PartitionId,
            Version = stream.Value.Version

        };
    }
}
