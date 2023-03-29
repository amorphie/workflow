

using System.ComponentModel.DataAnnotations.Schema;
using amorphie.core.Base;

public class Transition : EntityBaseWithOutId
{
    public string Name { get; set; } = string.Empty;
    
    public State FromState { get; set; } = default!;
    public string FromStateName { get; set; } = default!;

    public State? ToState { get; set; }
    public string? ToStateName { get; set; } 

    public ICollection<Translation> Titles { get; set; } = default!;

    public ZeebeMessage? Flow { get; set; }
    public string? FlowName { get; set; }

    public ICollection<Translation> Forms { get; set; } = default!;
    
    public string? ServiceName { get; set; } 
}