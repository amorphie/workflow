using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Dtos.Definition;
public class StateCreateDto
{
    public string Name { get; set; } = default!;
    public List<MultilanguageText> Titles { get; set; } = default!;
    public StatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
    public TransitionCreateDto? Transition { get; set; }
    public bool? IsPublicForm { get; set; }
    public List<MultilanguageText>? PublicForms { get; set; }
    public List<UiFormDto>? UiForms { get; set; }
    public MFATypeEnum? MfaType { get; set; }
    public string? SubWorkflowName { get; set; }
    public string? InitPageName { get; set; }
    public StateKind? Kind { get; set; }
    public List<StateRouteDto>? ToStates { get; set; }
}

