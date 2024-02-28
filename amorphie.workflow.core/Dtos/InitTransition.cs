using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

public class InitTransition
{
    public string? transition { get; set; }
    public string? type { get; set; }
    [JsonPropertyName("require-data")]
    public bool? requireData { get; set; }
    [JsonPropertyName("has-view-variant")]
    public bool? hasViewVariant { get; set; }
}