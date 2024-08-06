using System.Text.Json.Nodes;
using System.Text.Json;
using amorphie.workflow.core.Helper;

namespace amorphie.workflow.core.Logging;

public static class LoggingHelperAsJson
{
    private static string[]? _redactKeys;
    public static JsonObject? FilterResponse(JsonObject responseAsJson, string[] redactKeys)
    {
        if (responseAsJson == null)
        {
            return null;
        }
        _redactKeys = redactKeys;
        try
        {
            if (responseAsJson == null || redactKeys.Length == 0)
            {
                return null;
            }
            var keys = responseAsJson.Select(p => p.Key).ToList();
            foreach (var key in keys)
            {
                if (redactKeys.Contains(key))
                {
                    responseAsJson[key] = "***";
                    continue;
                }
                if (responseAsJson[key] is not null)
                {
                    if (responseAsJson[key]!.GetValueKind() == JsonValueKind.Object)
                    {
                        var innerDict = responseAsJson[key] as IDictionary<string, JsonNode>;
                        if (innerDict != null)
                        {
                            var decResult = FilterDictionary(innerDict);
                            //responseAsJson[key] = WfJsonSerializer.Serialize(decResult);
                            responseAsJson[key] = decResult as JsonObject;

                        }
                    }
                    else if (responseAsJson[key]!.GetValueKind() == JsonValueKind.String)
                    {
                        responseAsJson[key] = FilterString(key, responseAsJson[key]!.ToString());
                    }
                }
            }

            return responseAsJson;
        }
        catch (Exception)
        {

            return null;
        }
    }
    public static IDictionary<string, JsonNode> FilterDictionary(IDictionary<string, JsonNode> data)
    {
        var keys = data.Keys.ToList();
        foreach (var key in keys)
        {
            if (_redactKeys!.Contains(key))
            {
                data[key] = "***";
                continue;

            }
            if (data[key] is not null)
            {
                if (data[key].GetValueKind() == JsonValueKind.Object)
                {
                    var innerDict = data[key] as IDictionary<string, JsonNode>;
                    if (innerDict != null)
                    {
                        var decResult = FilterDictionary(innerDict);
                        //data[key] = WfJsonSerializer.Serialize(decResult);
                        data[key] =decResult as JsonObject;
                    }
                }
                else if (data[key].GetValueKind() == JsonValueKind.String)
                {
                    data[key] = FilterString(key, data[key].ToString());
                }
            }
        }
        return data;
    }
    static string FilterString(string key, string textInResponse)
    {
        if (_redactKeys!.Contains(key))
        {
            return "***";
        }
        return textInResponse;
    }
}

