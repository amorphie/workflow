using amorphie.workflow.core.Enums;


namespace amorphie.workflow.core.Dtos.Definition;
public class TransitionCreateDto
{
    public string? ServiceName { get; set; }
    public string? Message { get; set; }
    public string? Gateway { get; set; }
    public PageCreateDto? Page { get; set; }
    public TypeofUiEnum? TypeofUi { get; set; }
    public TransitionButtonType? ButtonType { get; set; }
}

