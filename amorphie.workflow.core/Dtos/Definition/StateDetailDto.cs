using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Dtos.Definition;
public class StateDetailDto
{
    public string Name { get; set; } = default!;
    public MultilanguageText? Title { get; set; }
    public StatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
    public TransitionCreateDto? TransitionCreateDto { get; set; }
    public bool? IsPublicForm { get; set; }
    public List<UiFormDto>? PublicForms { get; set; }
    public MFATypeEnum? MfaType { get; set; }
    public string? SubWorkflowName { get; set; }
    public string? InitPageName { get; set; }
    public StateKind Kind { get; set; }
    public List<StateRouteDto> ToStates { get; set; }
}

