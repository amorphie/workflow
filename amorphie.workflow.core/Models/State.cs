
using amorphie.core.Base;
using amorphie.core.Enums;

public class State : EntityBaseWithOutId
{
    public Workflow? Workflow { get; set; }
    public string? WorkflowName { get; set; }

    public string Name { get; set; } = string.Empty;
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<Translation> Descriptions { get; set; } = default!;

    public ICollection<Transition> Transitions { get; set; } = default!;
    public bool? IsPublicForm{ get; set; }
    public ICollection<Translation>? PublicForms { get; set; } = default!;

    public ZeebeMessage? OnEntryFlow { get; set; }
    public ZeebeMessage? OnExitFlow { get; set; }

    public StatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
}





