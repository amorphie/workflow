

using System.ComponentModel.DataAnnotations.Schema;
using amorphie.core.Base;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;

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

    public Page? Page { get; set; }
    public Guid? PageId { get; set; }
    public ICollection<UiForm>? UiForms { get; set; }
    public ICollection<Translation> Forms { get; set; } = default!;
    public ICollection<Translation> Pages { get; set; } = default!;
    public ICollection<Translation> HistoryForms { get; set; } = default!;

    public string? ServiceName { get; set; }
    public TypeofUiEnum? TypeofUi { get; set; }
}