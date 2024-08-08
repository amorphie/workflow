using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;
     public class TemplateEngineSemVerListResponse
    {
        public TemplateDefinitionNames[]? templateDefinitionNames { get; set; }
    }
    public class TemplateDefinitionNames 
    {
        [JsonPropertyNameAttribute("name")]
        public string? Name { get; set; }
         [JsonPropertyNameAttribute("semanticVersions")]

        public string[]? SemanticVersions { get; set; }
    }
