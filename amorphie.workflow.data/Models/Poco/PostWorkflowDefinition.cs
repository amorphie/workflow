
public abstract record PostWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions);

public record PostFSMWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions) : PostWorkflowDefinitionRequest(name, descriptions);
public record PostZeebeWorkflowDefinitionRequest(string name, MultilanguageText[] descriptions, string process, string gateway) : PostWorkflowDefinitionRequest(name, descriptions);


public abstract record PostWorkflowDefinitionReesponse(string name);