
using System.Text.Json;
using NJsonSchema;
using amorphie.workflow.core.Extensions;
namespace amorphie.workflow.service.Filters;
public class FilterHelper
{
    public static async Task<dynamic> FilterResponseAsync(JsonElement body, string schema)
    {
        if (body.TryConvertToDictionary(out Dictionary<string, object>? pairs) && pairs != null)
        {
            var theSchema = await JsonSchema.FromJsonAsync(schema);
            var tObjectKeysLower = pairs.Select(x => x.Key);
            var keyToBeStayed = theSchema.Properties.Where(p => tObjectKeysLower.Contains(p.Key))
                .Select(p => p.Key)
                .ToList();
            var tNewObject = pairs.Where(p => keyToBeStayed.Contains(p.Key)).ToList();
            return tNewObject;
        }
        return body;
    }
}