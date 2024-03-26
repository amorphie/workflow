using System.Text.Json;
namespace amorphie.workflow.core.Extensions;
public static class JsonSerializerExtension
{

    public static dynamic TryDeserialize(this string jsonString)
    {
        try
        {
            return JsonSerializer.Deserialize<dynamic>(jsonString) ?? "";
        }
        catch
        {
            return jsonString;
        }
    }

}
