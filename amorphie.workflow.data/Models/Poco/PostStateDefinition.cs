
public record PostStateDefinitionRequest(string name, string title, bool isFinalState, PostTransitionDefinitionRequest[] transitions);
public record PostTransitionDefinitionRequest(string name, MultilanguageText[] title, string toState, string? form);

public record PostStateDefinitionResponse(string name);





