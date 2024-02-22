
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
        string transitionName = body[ZeebeVariableKeys.LastTransition]!.ToString();
        var workerBody = new WorkerBody
        {
            InstanceId = new Guid(body[ZeebeVariableKeys.InstanceId]?.ToString() ?? ""),
            PageUrl = body[ZeebeVariableKeys.PageUrl]?.ToString() ?? "",
            Message = body[ZeebeVariableKeys.Message]?.ToString() ?? "",
            ErrorCode = body[ZeebeVariableKeys.ErrorCode]?.ToString() ?? "",
            LastTransition = transitionName
        };
        var bodyHeaders = body["Headers"];
        var workerBodyHeaders = bodyHeaders.Deserialize<WorkerBodyHeaders>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });

        //TODO:  variable with (TRX-) will be deleted
        var workerBodyTrxDatasDyna = body[$"TRX-{transitionName}"];
        var workerBodyTrxDatas = workerBodyTrxDatasDyna.Deserialize<WorkerBodyTrxDatas>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
        workerBody.WorkerBodyTrxDataList.Add($"TRX-{transitionName}", workerBodyTrxDatas);


        transitionName = transitionName.DeleteUnAllowedCharecters();

        var workerBodyTrxDatasDynamic2 = body[$"TRX{transitionName}"];
        var workerBodyTrxDatas2 = workerBodyTrxDatasDynamic2.Deserialize<WorkerBodyTrxDatas>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
        workerBody.WorkerBodyTrxDataList.Add($"TRX{transitionName}", workerBodyTrxDatas2);


        workerBody.Headers = workerBodyHeaders;
        return workerBody;
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
    public Dictionary<string, WorkerBodyTrxDatas>? WorkerBodyTrxDataList { get; set; } = new();
}

public class WorkerBodyHeaders
{
    public string? XTokenId { get; set; }
    public string? ACustomer { get; set; }
    public string? XDeviceId { get; set; }
    public string? XRequestId { get; set; }

}
public class WorkerBodyTrxDatas
{
    public WorkerBodyTrxInnerDatas? Data { get; set; }
    public Guid TriggeredBy { get; set; }
    public Guid TriggeredByBehalfOf { get; set; }
}
public class WorkerBodyTrxInnerDatas
{

    public dynamic EntityData { get; set; } = default!;
    public dynamic? FormData { get; set; }
    public dynamic? AdditionalData { get; set; }
    public bool GetSignalRHub { get; set; }
    public dynamic? RouteData { get; set; }
    public dynamic? QueryData { get; set; }
    public string? SetStateVia { get; set; }
}