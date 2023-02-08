
/// <summary>
/// Abstract record for workflow definition
/// </summary>

public abstract record GetWorkflowDefinition(string name, string description, string[] entities, string[] tags);

/// <summary>
/// State Machine workflow definition record
/// </summary>
/// <param name="name">Workflow name</param>
/// <param name="description">Workflow description as expected language</param>
/// <param name="entities">Entity list to which the workflow can be applied.</param>
/// <param name="tags">Workflow related tag list.</param>
public record GetFSMWorkflowDefinition(string name, string description, string[] entities, string[] tags) : GetWorkflowDefinition(name, description, entities, tags);


/// <summary>
/// Zeebe based workflow definition record
/// </summary>
public record GetZeebeWorkflowDefinition(string name, string description, string[] entities, string[] tags, string process, string gateway) : GetWorkflowDefinition(name, description, entities, tags);
