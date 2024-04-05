
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;

public class State : EntityBaseWithOutId
{
    public Workflow? Workflow { get; set; }
    public string? WorkflowName { get; set; }

    public string Name { get; set; } = string.Empty;
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<Translation> Descriptions { get; set; } = default!;

    public ICollection<Transition> Transitions { get; set; } = default!;
    public string[]? AllowedSuffix { get; set; }
    public ICollection<StateToState> FromStates { get; set; } = default!;
    public bool? IsPublicForm { get; set; }
    [Obsolete("UiForms took its place")]
    public ICollection<Translation>? PublicForms { get; set; } = default!;
    public ICollection<amorphie.workflow.core.Models.UiForm>? UiForms { get; set; }

    public ZeebeMessage? OnEntryFlow { get; set; }
    public ZeebeMessage? OnExitFlow { get; set; }

    public StatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
    public StateKind? Kind { get; set; }
    public MFATypeEnum? MFAType { get; set; }

    public Workflow? SubWorkflow { get; set; }
    public string? SubWorkflowName { get; set; }
    public string? InitPageName { get; set; }


    #region Transtion Props
    public string? FlowName { get; set; }

    public bool? requireData { get; set; }

    public Page? Page { get; set; }
    public Guid? PageId { get; set; }
    //TODO:Merge Foreign keys 

    // public ICollection<TransitionRole>? TransitionRoles { get; set; }
    // public ICollection<Translation> Forms { get; set; } = default!;
    // public ICollection<Translation> Pages { get; set; } = default!;
    // public ICollection<Translation> HistoryForms { get; set; } = default!;


    public string? ServiceName { get; set; }
    public TypeofUiEnum? TypeofUi { get; set; }
    public TransitionButtonType? transitionButtonType { get; set; }


    #endregion

}





