using System.Text.Json;
using amorphie.workflow.core.Extensions;
using amorphie.workflow.core.Helper;
namespace amorphie.workflow.service.Filters;
public class FilterHelper
{
    public static async Task<dynamic> FilterResponseAsync(JsonElement body, NJsonSchema.JsonSchema schema)
    {
        if (body.TryConvertToDictionary(out Dictionary<string, object>? pairs) && pairs != null)
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
    public static dynamic FilterAndEncrypt(JsonElement body, NJsonSchema.JsonSchema schema, string instanceId)
    {
        if (body.TryConvertToDictionary(out Dictionary<string, object>? pairs) && pairs != null)
        {

            var tObjectKeysLower = pairs.Select(x => x.Key);
            var keyToBeStayed = schema.Properties.Where(p => tObjectKeysLower.Contains(p.Key))
                .Select(p => p.Key)
                .ToList();

            var tNewObject = pairs.Where(p => keyToBeStayed.Contains(p.Key)).ToDictionary();

            foreach (var item in schema.Properties)
            {
                bool? hasEncryptKey = item.Value.ExtensionData?.TryGetValue("$encrypt", out _);
                if (hasEncryptKey == true)
                {
                    var value = tNewObject[item.Key].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        var key = AesHelper.CreateAesKey(instanceId);
                        var encrypted = AesHelper.EncryptString(key, value);
                        tNewObject[item.Key] = encrypted;

                    }
                }
            }
            var ser = WfJsonSerializer.Serialize(tNewObject);
            var des = WfJsonSerializer.Deserialize<object>(ser);

            return des ?? body;
        }
        return body;
    }
}