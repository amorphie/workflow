
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using amorphie.workflow.core.Constants;

namespace amorphie.workflow.core.Dtos;

public class JsonObjectConverter
{
    public static WorkerBody JsonToWorkerBody(JsonObject body)
    {
        var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
        string transitionName = body[ZeebeVariableKeys.LastTransition]!.ToString();
        var workerBody = new WorkerBody
        {
            InstanceId = new Guid(body[ZeebeVariableKeys.InstanceId]?.ToString() ?? ""),
            PageUrl = body[ZeebeVariableKeys.PageUrl]?.ToString() ?? "",
            Message = body[ZeebeVariableKeys.Message]?.Deserialize<string>(opt) ?? body[ZeebeVariableKeys.message]?.Deserialize<string>(opt) ?? "",
            ErrorCode = body[ZeebeVariableKeys.ErrorCode]?.Deserialize<string>(opt) ?? body[ZeebeVariableKeys.errorCode]?.Deserialize<string>(opt) ?? "",
            LastTransition = transitionName
        };

        foreach (var item in body.Where(p => p.Key.StartsWith("TRX")))
        {
            if (workerBody.WorkerBodyTrxDataList!.ContainsKey(item.Key))
                continue;
                WorkerBodyTrxDatas? value=null;
                try
                {
                     value = item.Value.Deserialize<WorkerBodyTrxDatas>(opt) ?? new WorkerBodyTrxDatas();
                }
                catch(Exception)
                {
                       throw new Exception(item.Key+" JsonBody is not valid format");
                }
           
            
            workerBody.WorkerBodyTrxDataList.Add(item.Key, value);
        }
        var bodyHeaders = body["Headers"];
        var workerBodyHeaders = bodyHeaders.Deserialize<WorkerBodyHeaders>(opt);
        workerBody.Headers = workerBodyHeaders;
        return workerBody;
    }

    public static WorkerBodyTrxDatas GetWorkerBodyTrxData(WorkerBody workerBody)
    {
        var data = workerBody.WorkerBodyTrxDataList!.GetValueOrDefault($"TRX{workerBody.LastTransition.DeleteUnAllowedCharecters()}");
        //Data is null for -got-first-
        if (data == null)
        {
            data = workerBody.WorkerBodyTrxDataList!.FirstOrDefault().Value;
        }
        return data;
    }
    public static WorkerBody DynamicToWorkerBody(dynamic body)
    {
        var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

        IDictionary<string, object> propertyValues = (IDictionary<string, object>)body;

        var workerBody = new WorkerBody
        {
            InstanceId = new Guid(propertyValues.FirstOrDefault(p => p.Key == ZeebeVariableKeys.InstanceId).ToString()),
            Message = propertyValues.FirstOrDefault(p => p.Key == ZeebeVariableKeys.Message || p.Key == ZeebeVariableKeys.message).ToString(),
            ErrorCode = propertyValues.FirstOrDefault(p => p.Key == ZeebeVariableKeys.ErrorCode || p.Key == ZeebeVariableKeys.errorCode).ToString()
        };

        foreach (var item in propertyValues.Where(p => p.Key.StartsWith("TRX")))
        {
            if (workerBody.WorkerBodyTrxDataList!.ContainsKey(item.Key))
                continue;
            if (item.Value is WorkerBodyTrxDatas value)
            {
                workerBody.WorkerBodyTrxDataList.Add(item.Key, value);
            }
        }
        return workerBody;
    }

    private static string GetStringFromDynamic(dynamic body, string propName)
    {
        string value;
        try
        {
            value = body.GetProperty(propName).ToString();
        }
        catch (Exception ex)
        {
            value = string.Empty;
        }
        return value;
    }

}
public class WorkerBody
{
    public string LastTransition { get; set; } = default!;
    public string PageUrl { get; set; } = default!;
    public string? Message { get; set; }
    public string? ErrorCode { get; set; }
    public Guid InstanceId { get; set; } = default!;

    public WorkerBodyHeaders? Headers { get; set; } = new();
    public Dictionary<string, WorkerBodyTrxDatas>? WorkerBodyTrxDataList { get; set; } = [];
}

public class WorkerBodyHeaders
{
    public string? XTokenId { get; set; }
    public string? ACustomer { get; set; }
    public string? XDeviceId { get; set; }
    public string? XRequestId { get; set; }
    public string? user_reference { get; set; }

}
public class WorkerBodyTrxDatas
{
    public WorkerBodyTrxInnerDatas? Data { get; set; }
    public Guid? TriggeredBy { get; set; }
    public Guid? TriggeredByBehalfOf { get; set; }
}
public class WorkerBodyTrxInnerDatas
{

    public JsonObject EntityData { get; set; } = default!;
    public dynamic? FormData { get; set; }
    public JsonObject? AdditionalData { get; set; }
    public bool GetSignalRHub { get; set; }
    public dynamic? RouteData { get; set; }
    public dynamic? QueryData { get; set; }
    public string? SetStateVia { get; set; }
}

public class InstanceStateChangeDto
{
    public Guid InstanceId { get; set; } = default!;
    public string TargetState { get; set; } = default!;
}