using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;

public class TemplateEngineGetDefinitionResponseModel
{
    public bool? hasNextPage { get; set; }
    public List<TemplateEngineTemplateDefinitions>? templateDefinitions { get; set; }
}
public class TemplateEngineTemplateDefinitions
{
    public string? name { get; set; }
    [JsonPropertyName("master-template")]
    public string? masterTemplate { get; set; }
    public string? template { get; set; }
    [JsonPropertyName("semantic-version")]
    public string? semanticVersion { get; set; }
    [JsonPropertyName("dynamic-data")]
    public dynamic? dynamicData { get; set; }
}
