
public  record GetStateDefinition(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions);

public record GetStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    GetStateDefinition(name, title, baseStatus, transitions);
public record GetStartStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    GetStateDefinition(name, title, baseStatus, transitions);
public record GetFinishStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    GetStateDefinition(name, title, baseStatus, transitions);


public record GetTransitionDefinition(string name, string title, string toState, string? form);

public record GetFSMTransitionDefinition(string name, string title, string toState, string? form) : GetTransitionDefinition(name, title, toState, form);
public record GetZeebeTransitionDefinition(string name, string title, string toState, string? form, string process, string gateway) : GetTransitionDefinition(name, title, toState, form);

