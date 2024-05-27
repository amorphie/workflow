using amorphie.core.Base;
using amorphie.workflow.core.Dtos.Definition;

namespace amorphie.workflow.service.Db.Abstracts;
public interface IWorkflowService
{
    Task<Response> SaveAsync(WorkflowCreateDto data,CancellationToken token);
    Task Insert(WorkflowCreateDto data);
    void Update(WorkflowCreateDto data, Workflow existingRecord);
    Task<Response<Workflow>> GetAsync(string workflowName);
}
