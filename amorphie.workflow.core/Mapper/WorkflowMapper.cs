
using AutoMapper;

namespace amorphie.workflow.core.Mapper
{
    public class WorkflowMapper : Profile
    {
        public WorkflowMapper()
        {
            CreateMap<Workflow, PostWorkflowDefinitionResponse>()
             .ConstructUsing(x=> new PostWorkflowDefinitionResponse(x.Name))
         .ReverseMap();
          CreateMap<GetWorkflowDefinition, Workflow>();
        }
    }
}