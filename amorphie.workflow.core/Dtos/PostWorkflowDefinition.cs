

using amorphie.core.Enums;
using amorphie.workflow.core.Dtos;

/// <param name="name"></param>
/// <param name="title"></param>
/// <param name="entities"></param>
/// <param name="tags"></param>
/// <param name="status"></param>
/// <param name="historyForms"></param>
/// <param name="recordId"></param>
/// <param name="IsForbiddenData"></param>
public record PostWorkflowDefinitionRequest(
    string name, 
    MultilanguageText[] title, 
    PostWorkflowEntity[]? entities, 
    string[] tags, 
    WorkflowStatus status, 
    MultilanguageText[]? historyForms, 
    string recordId, 
    bool? IsForbiddenData);

public record PostFSMWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags, WorkflowStatus status, MultilanguageText[]? historyForms, string recordId, bool? IsForbiddenData) : PostWorkflowDefinitionRequest(name, title, entities, tags, status, historyForms, recordId, IsForbiddenData);
public record PostZeebeWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags, WorkflowStatus status, MultilanguageText[]? historyForms, string process, string gateway, string recordId, bool? IsForbiddenData) : PostWorkflowDefinitionRequest(name, title, entities, tags, status, historyForms, recordId, IsForbiddenData);

public record PostWorkflowDefinitionResponse(string name);

public record PostWorkflowEntity(string name, bool isExclusive, bool isStateManager, StatusType[] availableInStatus);