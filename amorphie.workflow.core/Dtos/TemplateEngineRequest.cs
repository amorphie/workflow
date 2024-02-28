using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos
{
    public class TemplateEngineRequest
    {
        [JsonPropertyNameAttribute("name")]
        public string? Name { get; set; }
        [JsonPropertyNameAttribute("render-id")]
        public Guid RenderId { get; set; }
        [JsonPropertyNameAttribute("render-data")]
        public dynamic? RenderData { get; set; }
        [JsonPropertyNameAttribute("render-data-for-log")]
        public dynamic? RenderDataForLog { get; set; }
        [JsonPropertyNameAttribute("semantic-version")]
        public string? SemVer { get; set; }
        [JsonPropertyNameAttribute("process-name")]
        public string? ProcessName { get; set; }
        [JsonPropertyNameAttribute("item-id")]
        public string? ItemId { get; set; }
        [JsonPropertyNameAttribute("action")]
        public string? Action { get; set; }
        [JsonPropertyNameAttribute("identity")]
        public string? Identity { get; set; }
        [JsonPropertyNameAttribute("customer")]
        public string? Customer { get; set; }

    }
}