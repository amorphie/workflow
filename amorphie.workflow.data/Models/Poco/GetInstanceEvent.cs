
public record GetInstanceEventResponse(
    int code,
    string name,
    string description,
    Dictionary<string, string> additionalData,
    DateTime CreatedAt
    );


