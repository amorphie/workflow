
public abstract record PostWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions, string[] entities, string[] tags);

public record PostFSMWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions, string[] entities, string[] tags) : PostWorkflowDefinitionRequest(name, descriptions, entities, tags);
public record PostZeebeWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions, string[] entities, string[] tags, string process, string gateway) : PostWorkflowDefinitionRequest(name, descriptions, entities, tags);

public abstract record PostWorkflowDefinitionResponse(string name);