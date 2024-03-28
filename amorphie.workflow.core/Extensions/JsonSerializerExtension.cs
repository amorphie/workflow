using System.Text;
using System.Text.Json;
using System.Text.Unicode;
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
