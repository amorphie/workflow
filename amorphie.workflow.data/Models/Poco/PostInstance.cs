
public record PostInstanceRequest(
    string entity, 
    string entityRecordId, 
    Guid instanceId, 
    string workflow, 
    string transation, 
    bool cretateHubToken, 
    dynamic entityData);

public record PostInstanceResponse(
    Guid InstanceId, 
    string? signalRHub, 
    string? signalRHubToken
    );
