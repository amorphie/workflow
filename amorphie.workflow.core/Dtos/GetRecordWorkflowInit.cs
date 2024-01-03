using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

public class GetRecordWorkflowInit
{
    public string? state { get; set; }
    [JsonPropertyName("view-source")]
    public string? viewSource { get; set; }
    public List<InitTransition>? transition { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("init-page-name")]
    public string? initPageName { get; set; }
}
public class InstanceStateTransitions : GetRecordWorkflowInit
{
    [JsonPropertyName("base-state")]
    public string? baseState { get; set; }
}
