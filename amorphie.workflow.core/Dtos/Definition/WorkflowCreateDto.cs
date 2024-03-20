using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;

namespace amorphie.workflow.core.Dtos.Definition;

public class WorkflowCreateDto
{
    public string Name { get; set; } = default!;
    public Guid RecordId { get; set; }
    public List<MultilanguageText>? Titles { get; set; }
    public string[]? Tags { get; set; }
    public WorkflowStatus? Status { get; set; }
    public List<WorkflowEntityDto> Entities { get; set; } = default!;
    public List<StateCreateDtoLegacy>? States { get; set; }
    public bool? IsForbiddenData { get; set; }
    public string? Hash { get; set; }
    public List<MultilanguageText>? HistoryForms { get; set; }

    public List<StateCreateDto>? NewStates { get; set; }



}


