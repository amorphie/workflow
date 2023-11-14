

using amorphie.core.Enums;
using amorphie.workflow.core.Dtos;
/// <summary>
/// Abstract record for workflow definition
/// </summary>
public record GetWorkflowDefinition(string name, string title, string[] tags, GetWorkflowEntity[] entities, string? recordId);

/// <summary>
/// State Machine workflow definition record
/// </summary>
/// <param name="name">Workflow name</param>
/// <param name="title">Workflow description as expected language</param>
/// <param name="entities">Entity list to which the workflow can be applied.</param>
/// <param name="tags">Workflow related tag list.</param>
public record GetFSMWorkflowDefinition(string name, string title, string[] tags, GetWorkflowEntity[] entities, string recordId) : GetWorkflowDefinition(name, title, tags, entities, recordId);

/// <summary>
/// Zeebe based workflow definition record
/// </summary>
public record GetZeebeWorkflowDefinition(string name, string title, string[] tags, GetWorkflowEntity[] entities, string process, string gatewa, string recordId) : GetWorkflowDefinition(name, title, tags, entities, recordId);
/// <summary>
///  Workflow definition record with states
/// </summary>
public record GetWorkflowDefinitionWithStates(string name, string title, string[] tags, GetWorkflowEntity[] entities, GetStateDefinitionWithMultiLanguage[] states, string recordId) : GetWorkflowDefinition(name, title, tags, entities, recordId);
/// <summary>
/// Workflow entity relation
/// </summary>
/// <param name="name">Entity name</param>
/// <param name="isExclusive">For every record just one exclusive workflow instance can run. Exclusive workflows are mutually exclusive. Non exclusive workflows can run parallely</param>
/// <param name="isStateManager">When set true and if entity has status property, related workflow is source of state. </param>
/// <param name="availableInStatus">When this workflow can initate. This is informational property for consumer</param>
public record GetWorkflowEntity(string name, bool isExclusive, bool isStateManager, StatusType[]? availableInStatus);

