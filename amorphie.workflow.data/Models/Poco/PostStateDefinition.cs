
public record PostStateDefinitionRequest(string name, string title, bool isFinalState, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions);
public record PostTransitionDefinitionRequest(string name, MultilanguageText[] title, string toState, string? form);

public record PostStateDefinitionResponse(string name);





