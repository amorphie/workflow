
public record PostTransitionRequest(
    dynamic formData,
    dynamic entityData,
    dynamic variables,
    bool cretateHubToken
    );

public record PostTransitionResponse(
    Dictionary<string, dynamic> entityUpdates,
    string? signalRHub, 
    string? signalRHubToken
    );