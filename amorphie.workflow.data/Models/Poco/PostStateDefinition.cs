
public record PostStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus,StateType type, PostTransitionDefinitionRequest[] transitions);


public record PostStartStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Start ,transitions);
public record PostFinishStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Finish ,transitions);
public record PostAutoTransitStateDefinitionRequest(string name, MultilanguageText title, BaseStatusType baseStatus, PostTransitionDefinitionRequest[] transitions, long ExecuteInMinutes) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Standart ,transitions);


public record PostTransitionDefinitionRequest(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState, string? message, string? gateway);

public record PostFSMTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState) : PostTransitionDefinitionRequest(name, title, toState, form,fromState,null,null);
public record PostZeebeTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState, string message, string gateway) : PostTransitionDefinitionRequest(name, title, toState, form,fromState,message,gateway);

public record PostStateDefinitionResponse(string name);





