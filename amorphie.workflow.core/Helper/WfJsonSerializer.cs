using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace amorphie.workflow.core.Helper;
public static class WfJsonSerializer
{
    private static JsonSerializerOptions opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

    public static string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, opt);
    }
    public static TValue? Deserialize<TValue>(string json)
    {
        return JsonSerializer.Deserialize<TValue>(json, opt);
    }
}

