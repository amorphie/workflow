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
    [JsonPropertyNameAttribute("master-template")]
    public string? masterTemplate { get; set; }
    public string? template { get; set; }
    [JsonPropertyNameAttribute("semantic-version")]
    public string? semanticVersion { get; set; }
    [JsonPropertyNameAttribute("dynamic-data")]
    public dynamic? dynamicData { get; set; }
}
