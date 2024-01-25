using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamExporters
{
    internal class ProcessInstanceExporter : BaseExporter, IExporter
    {
        string lastReadId;
        public ProcessInstanceExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
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

                lastReadId = result.Last().Id;
                foreach (var process in result)
                {
                    var value = process.Values[0].Value.ToString();
                    var stream = JsonSerializer.Deserialize<ProcessInstanceStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (stream == null)
                    {
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
                        entity.RedisId = process.Id;
                        dbContext.ProcessInstances.Add(entity);
                    }
                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        messageToBeDeleted.Add(process.Id);
                    }
                }
                var deletedItemsCount = await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());
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
}
