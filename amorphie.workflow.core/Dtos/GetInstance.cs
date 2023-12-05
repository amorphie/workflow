
public enum GetInstanceStatusType {
    All,
    Completed,
    Running,
    Suspended
}

public record GetInstanceResponse(
    string EntityName,
    string RecordId,
    Guid Id,
    string WorkflowName,
    GetStateDefinition State,
    DateTime CreatedAt,
    DateTime LastTransitionAt
    );


