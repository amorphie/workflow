
public record GetWorkflowDefinition(string name);

public record GetFSMWorkflowDefinition(string name) : GetWorkflowDefinition(name);
public record GetZeebeWorkflowDefinition(string name, string process, string gateway, string caCertificatePath) : GetWorkflowDefinition(name);
