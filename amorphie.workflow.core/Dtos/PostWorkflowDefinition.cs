
using amorphie.core.Base;
using amorphie.core.Enums;

public  record PostWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[]? entities, string[] tags,WorkflowStatus status);

public record PostFSMWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags,WorkflowStatus status) : PostWorkflowDefinitionRequest(name, title, entities, tags,status);
public record PostZeebeWorkflowDefinitionRequest(string name, MultilanguageText[] title, PostWorkflowEntity[] entities, string[] tags,WorkflowStatus status, string process, string gateway) : PostWorkflowDefinitionRequest(name, title, entities, tags,status);

public  record PostWorkflowDefinitionResponse(string name);

public record PostWorkflowEntity(string name, bool isExclusive, bool isStateManager, StatusType[] availableInStatus);