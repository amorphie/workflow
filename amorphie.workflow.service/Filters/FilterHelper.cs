using System.Text.Json;
using System.Text.Json.Nodes;
using amorphie.workflow.core.Extensions;
using amorphie.workflow.core.Helper;
using NJsonSchema;
namespace amorphie.workflow.service.Filters;
public class FilterHelper
{
    public static async Task<dynamic> FilterResponseAsync(JsonElement body, NJsonSchema.JsonSchema schema)
    {
        if (body.TryConvertToJsonObject(out JsonObject? pairs) && pairs != null)
        {

            var tObjectKeysLower = pairs.Select(x => x.Key);
            var keyToBeStayed = schema.Properties.Where(p => tObjectKeysLower.Contains(p.Key))
                .Select(p => p.Key)
                .ToList();

            var tNewObject = pairs.Where(p => keyToBeStayed.Contains(p.Key)).ToDictionary();
            var ser = WfJsonSerializer.Serialize(tNewObject);
            var des = WfJsonSerializer.Deserialize<object>(ser);

            return des ?? body;
        }
        return body;
    }
    public static (dynamic, bool) FilterAndEncrypt(JsonElement body, NJsonSchema.JsonSchema schema, string instanceId)
    {
        bool hasAnyEncryption = false;
        if (body.TryConvertToJsonObject(out JsonObject? pairs) && pairs != null)
        {
            var filterResult = FilterAndEncryptJsonObject(pairs, schema, instanceId);
            var ser = WfJsonSerializer.Serialize(filterResult.Item1);
            var des = WfJsonSerializer.Deserialize<object>(ser);

            return (des ?? body, filterResult.Item2);
        }
        return (body, hasAnyEncryption);
    }

    public static (JsonObject, bool) FilterAndEncryptJsonObject(JsonObject data, NJsonSchema.JsonSchema schema, string instanceId)
    {
        var dataKeys = data.Where(p => p.Value != null).Select(p => p.Key).ToList();
        if (dataKeys is not null)
        {
            var keyToBeStayed = schema.Properties.Where(p => dataKeys.Contains(p.Key))
                .Select(p => p.Key)
                .ToList();

            var tNewObject = data.Where(p => keyToBeStayed.Contains(p.Key)).ToDictionary();
            if (tNewObject is not null)
            {
                var linqTest = schema.ActualProperties.Where(p => p.Value.ExtensionData?.ContainsKey("$encrypt") == true).ToList();
                var encResult = EncryptDict(tNewObject, schema.ActualProperties, instanceId);
                return (encResult.Item1 ?? data, encResult.Item2);
            }

        }
        //second param indicates if there is encryption or not
        return (data, false);
    }

    public static (JsonObject?, bool) EncryptDict(IDictionary<string, JsonNode>? data, IReadOnlyDictionary<string, JsonSchemaProperty> actualProperties, string instanceId)
    {
        bool hasAnyEncryption = false;

        if (data is not null)
        {
            foreach (var item in actualProperties)
            {
                bool? hasEncryptKey = item.Value.ExtensionData?.TryGetValue("$encrypt", out _);
                if (hasEncryptKey == true)
                {
                    var value = data[item.Key].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        var encrypted = AesHelper.EncryptString(instanceId, value);
                        data[item.Key] = encrypted;
                        hasAnyEncryption = true;
                    }
                    continue;
                }

                var itemType = item.Value.Type;
                var itemActualProp = item.Value.ActualSchema.ActualProperties;
                if (itemActualProp.Count > 0)
                {
                    var innerDict = data[item.Key] as IDictionary<string, JsonNode>;
                    var encResult = EncryptDict(innerDict, itemActualProp, instanceId);
                    if (encResult.Item1 != null)
                    {
                        data[item.Key] = encResult.Item1;
                    }
                }
            }
            return (data as JsonObject, hasAnyEncryption);
        }
        return (null, false);
    }

}