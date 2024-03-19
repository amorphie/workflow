using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Dtos.DefinitionLegacy;
public class StateCreateDtoLegacy
{
    public string Name { get; set; } = default!;
    public List<MultilanguageText>? Titles { get; set; }
    public StatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
    public List<TransitionCreateDtoLegacy>? Transitions { get; set; }
    public bool? IsPublicForm { get; set; }
    public List<MultilanguageText>? PublicForms { get; set; }
    public List<UiFormDto>? UiForms { get; set; }
    public MFATypeEnum? MfaType { get; set; }
    public string? SubWorkflowName { get; set; }
    public string? InitPageName { get; set; }

}

