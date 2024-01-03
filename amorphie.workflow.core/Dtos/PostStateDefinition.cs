
using amorphie.workflow.core.Dtos;
using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

public record PostStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, StateType type,
 PostTransitionDefinitionRequest[] transitions, bool? ispublicForm, UiFormDto[]? publicForms, MFATypeEnum? mfaType,
 string? subWorkflowName,string? initPageName);


public record PostStartStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions,
bool? ispublicForm, UiFormDto[]? publicForms, MFATypeEnum? mfaType,string? subWorkflowName,string? initPageName) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Start, transitions, ispublicForm, publicForms, mfaType,subWorkflowName,initPageName);
public record PostFinishStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions,
 bool? ispublicForm, UiFormDto[]? publicForms, MFATypeEnum? mfaType,string? subWorkflowName,string? initPageName) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Finish, transitions, ispublicForm, publicForms, mfaType,subWorkflowName,initPageName);
public record PostAutoTransitStateDefinitionRequest(string name, MultilanguageText title, StatusType baseStatus, PostTransitionDefinitionRequest[] transitions,
 long ExecuteInMinutes, bool? ispublicForm, UiFormDto[]? publicForms, MFATypeEnum? mfaType,string? subWorkflowName,string? initPageName) :
    PostStateDefinitionRequest(name, title, baseStatus, StateType.Standart, transitions, ispublicForm, publicForms, mfaType,subWorkflowName,initPageName);


public record PostTransitionDefinitionRequest(string name, MultilanguageText title, string toState, UiFormDto[]? form, string fromState, string? serviceName, string? message, string? gateway, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi, TransitionButtonType? buttonType);
public record PostPageDefinitionRequest(PageOperationType operation, PageType type, MultilanguageText? pageRoute, int? timeout);
public record PostPageDefinitionListMLRequest(PageOperationType operation, PageType type, MultilanguageText[]? pageRoute, int? timeout);

public record PostFSMTransitionDefinition(string name, MultilanguageText title, string toState, UiFormDto[]? form, string fromState, string? serviceName, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi, TransitionButtonType? buttonType) : PostTransitionDefinitionRequest(name, title, toState, form, fromState, serviceName, null, null, page, historyForms, typeofUi, buttonType);
public record PostZeebeTransitionDefinition(string name, MultilanguageText title, string toState, UiFormDto[]? form, string fromState, string? serviceName, string message, string gateway, PostPageDefinitionRequest? page, MultilanguageText[]? historyForms, TypeofUiEnum? typeofUi, TransitionButtonType? buttonType) : PostTransitionDefinitionRequest(name, title, toState, form, fromState, serviceName, message, gateway, page, historyForms, typeofUi, buttonType);

public record PostStateDefinitionResponse(string name);





