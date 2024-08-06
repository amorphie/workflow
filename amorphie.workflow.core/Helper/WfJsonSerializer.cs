using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace amorphie.workflow.core.Helper;
public static class WfJsonSerializer
{
    private static TextEncoderSettings GetEncoderSettings()
    {
        var encoderSettings = new TextEncoderSettings();
        encoderSettings.AllowCharacters('\u0027', '\u003E');
        encoderSettings.AllowRange(UnicodeRanges.All);
        return encoderSettings;
    }
    private static JsonSerializerOptions opt = new JsonSerializerOptions 
    { 
        PropertyNameCaseInsensitive = true,
        //WriteIndented = true,
        //Encoder = JavaScriptEncoder.Create(GetEncoderSettings())
        //Encoder = JavaScriptEncoder.Create(new TextEncoderSettings(UnicodeRanges.All))
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static string Serialize<TValue>(TValue value)
    {
        return JsonSerializer.Serialize(value, opt);
    }
    public static TValue? Deserialize<TValue>(string json)
    {
        return JsonSerializer.Deserialize<TValue>(json, opt);
    }
}

