
public enum GetInstanceStatusType
{
    All,
    Completed,
    Running,
    Suspended
}

public class GetInstanceResponse
{
    public  string EntityName {get;set;}
    public string RecordId{get;set;}
    public Guid Id{get;set;}
    public string WorkflowName{get;set;}
    public GetStateDefinition? State {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime? LastTransitionAt {get;set;}
    public dynamic? data {get;set;}
    public dynamic? additionalData {get;set;}
    public List<amorphie.workflow.core.Dtos.HumanTasks.HumanTaskDto>? humanTasks {get;set;}
    public bool? isHumanTask {get;set;}
    public string? viewSource {get;set;}
    };


