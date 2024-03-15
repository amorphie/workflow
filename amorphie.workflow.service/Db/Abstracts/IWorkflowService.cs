using amorphie.core.Base;
using amorphie.workflow.core.Dtos.DefinitionLegacy;

namespace amorphie.workflow.service.Db.Abstracts;
public interface IWorkflowService
{
    Task<Response> SaveAsync(WorkflowCreateDtoLegacy data);
    void Insert(WorkflowCreateDtoLegacy data);
    void Update(WorkflowCreateDtoLegacy data, Workflow existingRecord);
    Task<Response<Workflow>> GetAsync(string workflowName);
}
