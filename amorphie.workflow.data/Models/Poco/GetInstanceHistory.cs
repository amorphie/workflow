
public record GetInstanceTransitionHistoryResponse(
    Guid id,
    string fromState,
    string toState,
    string transition,
    dynamic entityData,
    dynamic formData,
    DateTime CreatedAt,
    GetInstanceEventHistoryResponse[] events
    );

public record GetInstanceEventHistoryResponse(
    Guid id,
    string name,
    Dictionary<string, string> details,
    Dictionary<string, string> inputData,
    Dictionary<string, string> outputData,
    DateTime CreatedAt
    );
