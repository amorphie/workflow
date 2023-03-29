
public enum GetInstanceStatusType {
    All,
    Completed,
    Running,
    Suspended
}

public record GetInstanceResponse(
    string entity,
    string entityRecordId,
    Guid instanceId,
    string workflow,
    GetStateDefinition State,
    DateTime CreatedAt,
    DateTime LastTransitionAt
    );


