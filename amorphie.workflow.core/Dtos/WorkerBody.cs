
namespace amorphie.workflow.core.Dtos;
public class WorkerBody
{
    public string LastTransition { get; set; } = default!;
    public string? HubMessage { get; set; }
    public string? HubErrorCode { get; set; }
    public Guid InstanceId { get; set; } = default!;

    public WorkerBodyHeaders? BodyHeaders { get; set; } = new();
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