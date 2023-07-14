
using amorphie.core.Base;
using amorphie.core.Enums;

public record PostStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus,StateType type ,PostTransitionDefinitionRequest[] transitions);


public record PostStartStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Start,transitions);
public record PostFinishStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Finish,transitions);
public record PostAutoTransitStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions, long ExecuteInMinutes) :
    PostStateDefinitionRequest(name, title, baseStatus,StateType.Standart ,transitions);


public record PostTransitionDefinitionRequest(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState,string? serviceName, string? message, string? gateway,PostPageDefinitionRequest? page);
public record PostPageDefinitionRequest(PageOperationType operation,PageType type,MultilanguageText pageRoute,int? timeout);

public record PostFSMTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState,string? serviceName,PostPageDefinitionRequest? page) : PostTransitionDefinitionRequest(name, title, toState, form,fromState,serviceName,null,null,page);
public record PostZeebeTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText?  form, string fromState,string? serviceName, string message, string gateway,PostPageDefinitionRequest? page) : PostTransitionDefinitionRequest(name, title, toState, form,fromState,serviceName,message,gateway,page);

public record PostStateDefinitionResponse(string name);





