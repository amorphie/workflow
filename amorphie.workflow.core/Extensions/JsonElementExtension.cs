using System.Text.Json;
namespace amorphie.workflow.core.Extensions;
public static class JsonElementExtension
{
    public static bool TryConvertToDictionary(this JsonElement obj, out Dictionary<string, object>? pairs)
    {
        try
        {
            if (obj.ValueKind == JsonValueKind.Object)
            {
                pairs = obj.Deserialize<Dictionary<string, object>>();
                return true;
            }
        }
        catch
        {
            // same result with parent scope
        }
        pairs = null;
        return false;
    }
}
