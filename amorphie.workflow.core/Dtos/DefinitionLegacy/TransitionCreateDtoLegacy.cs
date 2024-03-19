using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Enums;


namespace amorphie.workflow.core.Dtos.DefinitionLegacy;
public class TransitionCreateDtoLegacy
{
    public string? Name { get; set; }
    public List<MultilanguageText>? Titles { get; set; }

    public string? ToState { get; set; }
    public List<MultilanguageText>? Forms { get; set; }

    public string? FromState { get; set; }
    public string? ServiceName { get; set; }
    public string? Message { get; set; }
    public string? Gateway { get; set; }
    public PageCreateDto? Page { get; set; }
    public TypeofUiEnum? TypeofUi { get; set; }
    public List<UiFormDto>? UiForms { get; set; }



}

