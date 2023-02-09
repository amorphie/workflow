
public record PostStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions);


public record PostStartStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus, transitions);
public record PostFinishStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus, transitions);
public record PostAutoTransitStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions, long ExecuteInMinutes) :
    PostStateDefinitionRequest(name, title, baseStatus, transitions);


public record PostTransitionDefinitionRequest(string name, MultilanguageText title, string toState, string? form);

public record PostFSMTransitionDefinition(string name, MultilanguageText title, string toState, string? form) : PostTransitionDefinitionRequest(name, title, toState, form);
public record PostZeebeTransitionDefinition(string name, MultilanguageText title, string toState, string? form, string message, string gateway) : PostTransitionDefinitionRequest(name, title, toState, form);

public record PostStateDefinitionResponse(string name);





