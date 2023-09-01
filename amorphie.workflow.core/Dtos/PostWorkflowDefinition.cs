
using amorphie.core.Base;
using amorphie.core.Enums;

public record PostWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[]? entities, string[] tags, WorkflowStatus status, MultilanguageText[]? historyForms);

public record PostFSMWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags, WorkflowStatus status, MultilanguageText[]? historyForms) : PostWorkflowDefinitionRequest(name, title, entities, tags, status, historyForms);
public record PostZeebeWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags, WorkflowStatus status, MultilanguageText[]? historyForms, string process, string gateway) : PostWorkflowDefinitionRequest(name, title, entities, tags, status, historyForms);

public record PostWorkflowDefinitionResponse(string name);

public record PostWorkflowEntity(string name, bool isExclusive, bool isStateManager, StatusType[] availableInStatus);