﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamObjects;

public class IncidentStream
{
    public string Id { get; set; }
    public int PartitionId { get; set; }

    public IncidentStreamValue Value { get; set; }
    public long Key { get; set; }
    public long Timestamp { get; set; }
    public string? ValueType { get; set; }
    public string? BrokerVersion { get; set; }
    public int SourceRecordPosition { get; set; }
    public string Intent { get; set; }

    public string? RecordType { get; set; }
    public string? RejectionType { get; set; }
    public string? RejectionReason { get; set; }
    public int Position { get; set; }
    public int RecordVersion { get; set; }

}

public class IncidentStreamValue
{
    public string? ElementId { get; set; }
    public long JobKey { get; set; }
    public string? BpmnProcessId { get; set; }
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    public long ElementInstanceKey { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }

}

