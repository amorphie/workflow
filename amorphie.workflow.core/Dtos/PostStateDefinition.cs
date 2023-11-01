
using amorphie.workflow.core.Dtos;
using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

public record PostStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, StateType type, PostTransitionDefinitionRequest[] transitions, bool? ispublicForm, MultilanguageText[] publicForms);


public record PostStartStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions, bool? ispublicForm, MultilanguageText[] publicForms) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Start, transitions, ispublicForm, publicForms);
public record PostFinishStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions, bool? ispublicForm, MultilanguageText[] publicForms) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Finish, transitions, ispublicForm, publicForms);
public record PostAutoTransitStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions, long ExecuteInMinutes, bool? ispublicForm, MultilanguageText[] publicForms) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Standart, transitions, ispublicForm, publicForms);


public record PostTransitionDefinitionRequest(string name, MultilanguageText title, string toState, MultilanguageText? form, string fromState, string? serviceName, string? message, string? gateway, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi);
public record PostPageDefinitionRequest(PageOperationType operation, PageType type, MultilanguageText? pageRoute, int? timeout);

public record PostFSMTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText? form, string fromState, string? serviceName, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi) : PostTransitionDefinitionRequest(name, title, toState, form, fromState, serviceName, null, null, page, historyForms, typeofUi);
public record PostZeebeTransitionDefinition(string name, MultilanguageText title, string toState, MultilanguageText? form, string fromState, string? serviceName, string message, string gateway, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi) : PostTransitionDefinitionRequest(name, title, toState, form, fromState, serviceName, message, gateway, page, historyForms, typeofUi);

public record PostStateDefinitionResponse(string name);





