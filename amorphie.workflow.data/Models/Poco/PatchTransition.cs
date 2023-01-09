
public record PatchTransitionRequest(
    dynamic formData,
    dynamic entityData,
    bool cretateHubToken
    );

public record PatchTransitionResponse(
    Dictionary<string, dynamic> entityUpdates,
    string? signalRHub, 
    string? signalRHubToken
    );