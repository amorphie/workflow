
public abstract record GetWorkflowDefinition(string name, string description);

public record GetFSMWorkflowDefinition(string name, string description) : GetWorkflowDefinition(name, description);
public record GetZeebeWorkflowDefinition(string name, string description, string process, string gateway) : GetWorkflowDefinition(name, description);
