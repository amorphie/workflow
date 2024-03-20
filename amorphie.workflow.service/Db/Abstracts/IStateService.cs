using amorphie.core.Base;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;

namespace amorphie.workflow.service.Db.Abstracts;
public interface IStateService
{
    Task<Response> SaveBulkAsync(List<StateCreateDto> states, string workflowName);
    Task<Response> SaveAsync(StateCreateDto data, string workflowName);
    Task<Response<State>> GetAsync(string workflowName, string stateName);
    Task<Response<List<StateCreateDto>>> GetAllAsync(string workflowName);
    Task<Response> SaveStateRoutesAsync(StateRoutesDto data);

    //Legacy
    Task<Response> LegacySaveBulkAsync(WorkflowCreateDto data);
}
