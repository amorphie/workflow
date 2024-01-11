using amorphie.workflow.core.Constants;
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
    internal class ProcessInstanceExporter : IExporter
    {
        private readonly WorkflowDBContext dbContext;
        private readonly string consumerName;
        public ProcessInstanceExporter(WorkflowDBContext dbContext, string consumerName)
        {
            this.dbContext = dbContext;
            this.consumerName = consumerName;
        }
        public async Task Attach(IDatabase redisDb, CancellationToken cancellationToken)
        {
            if (!(await redisDb.KeyExistsAsync(ZeebeStreamKeys.PROCESS_INSTANCE)) ||
                (await redisDb.StreamGroupInfoAsync(ZeebeStreamKeys.PROCESS_INSTANCE)).All(x => x.Name != ZeebeStreamKeys.PROCESS_INSTANCE_GROUP))
            {
                await redisDb.StreamCreateConsumerGroupAsync(ZeebeStreamKeys.PROCESS_INSTANCE, ZeebeStreamKeys.PROCESS_INSTANCE_GROUP, "0-0", true);
            }

            string lastReadId = "-";
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //var result = await redisDb.StreamRangeAsync(PROCESS_INSTANCE, lastReadId, "+", 1, Order.Ascending);
                    var result = await redisDb.StreamRangeAsync(ZeebeStreamKeys.PROCESS_INSTANCE, lastReadId, "+");

                    //var result = await redisDb.StreamReadGroupAsync(PROCESS_INSTANCE, groupName, "avg-1", ">");

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
                                //ihtimal mi??
                                continue;
                            }
                            //ACTIVATE_ELEMENT
                            //ELEMENT_ACTIVATING
                            //ELEMENT_ACTIVATED
                            //COMPLETE_ELEMENT
                            //ELEMENT_COMPLETING
                            //ELEMENT_COMPLETED
                            //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor.

                            //if (entity.Value.BpmnElementType == "START_EVENT" && entity.Intent == "ELEMENT_COMPLETED")
                            //if (entity.Value.BpmnElementType == "START_EVENT" && entity.Intent == "ELEMENT_COMPLETED")
                            //{

                            //}
                            //else if (entity.Value.BpmnElementType == "INTERMEDIATE_CATCH_EVENT" && entity.Intent == "ELEMENT_COMPLETED")
                            //{

                            //}
                            //else
                            //{

                            //}

                            var entity = StreamToEntity(stream);
                            dbContext.ProcessInstances.Add(entity);
                            var savingResult = await dbContext.SaveChangesAsync();
                            if (savingResult > 0)
                            {
                                messageToBeDeleted.Add(entity.RedisId);
                            }
                        }
                        var deletedItemsCount = await redisDb.StreamDeleteAsync(ZeebeStreamKeys.PROCESS_INSTANCE, messageToBeDeleted.ToArray());

                    }
                    await Task.Delay(1000);
                }
            });
            await readTask;
        }
        private ProcessInstance StreamToEntity(ProcessInstanceStream stream)
        {
            return new ProcessInstance
            {
                BpmnProcessId = stream.Value.BpmnProcessId,
                Key = stream.Key, //Element specific
                Timestamp = stream.Timestamp,//Event created time in long format
                ValueType = stream.ValueType,
                BrokerVersion = stream.BrokerVersion,
                SourceRecordPosition = stream.SourceRecordPosition,
                Intent = stream.Intent,
                //CorrelationKey = stream.Value.CorrelationKey,
                //MessageName = stream.Value.MessageName,
                //Variables = stream.Value.Variables.ToJsonString(),
                //MessageKey = stream.Value.MessageKey,
                Position = stream.Position,
                ProcessInstanceKey = stream.Value.ProcessInstanceKey,
                ProcessDefinitionKey = stream.Value.ProcessDefinitionKey,
                RecordType = stream.RecordType,
                //RecordVersion = stream.RecordVersion,
                RejectionType = stream.RejectionType,
                RejectionReason = stream.RejectionReason,
                //TenantId=stream.Value.TenantId
            };
        }
    }
}
