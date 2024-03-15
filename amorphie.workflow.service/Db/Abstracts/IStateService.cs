using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;

namespace amorphie.workflow.service.Db.Abstracts;
public interface IStateService
{
    Task<Response> SaveBulkAsync(WorkflowCreateDto data, string workflowName, string language);
    Task<Response> SaveAsync(StateCreateDto data, string workflowName, string language);
    Task<Response<State>> GetAsync(string workflowName, string stateName);
    Task<Response<List<StateCreateDto>>> GetAllAsync(string workflowName);
    Task<Response> SaveStateRoutesAsync(StateRoutesDto data);
}
