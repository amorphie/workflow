
using amorphie.core.Base;
namespace amorphie.workflow.core.Models;
public class StateToState : EntityBase
{
    public State FromState { get; set; } = default!;
    public string FromStateName { get; set; } = default!;
    public State ToState { get; set; } = default!;
    public string ToStateName { get; set; } = default!;
    public bool IsDefault { get; set; }

}





