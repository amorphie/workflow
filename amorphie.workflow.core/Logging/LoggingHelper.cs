﻿using System.Text.Json.Nodes;
using System.Text.Json;

namespace amorphie.workflow.core.Logging;

public static class LoggingHelper
{
    private static string[]? _redactKeys;
    public static string FilterResponse(string responseBodyText, string[] redactKeys)
    {
        if (string.IsNullOrEmpty(responseBodyText))
        {
            return string.Empty;
        }
        _redactKeys = redactKeys;
        var responseAsJson = JsonSerializer.Deserialize<JsonObject>(responseBodyText);
        if (responseAsJson == null || redactKeys.Length == 0)
        {
            return responseBodyText;
        }
        try
        {
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
                            responseAsJson[key] = JsonSerializer.Serialize(decResult);
                        }
                    }
                    else if (responseAsJson[key]!.GetValueKind() == JsonValueKind.String)
                    {
                        responseAsJson[key] = FilterString(key, responseAsJson[key]!.ToString());
                    }
                }
            }

            return JsonSerializer.Serialize(responseAsJson);
        }
        catch (Exception)
        {

            return responseBodyText;
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
                        data[key] = JsonSerializer.Serialize(decResult);
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

