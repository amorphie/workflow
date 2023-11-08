
using AutoMapper;

namespace amorphie.workflow.core.Mapper
{
    public class WorkflowMapper : Profile
    {
        public WorkflowMapper()
        {
            CreateMap<Workflow, PostWorkflowDefinitionResponse>()
             .ConstructUsing(x => new PostWorkflowDefinitionResponse(x.Name))
         .ReverseMap();
            CreateMap<PostWorkflowDefinitionRequest, Workflow>()
       .ConstructUsing(x => new Workflow
       {
           WorkflowStatus = x.status,
           Name = x.name,
           Tags = x.tags,
           Titles = x.title.Select(s => new amorphie.core.Base.Translation
           {
               Label = s.label,
               Language = s.language
           }).ToList(),
           CreatedAt = DateTime.Now,
           CreatedByBehalfOf = Guid.NewGuid(),
           Entities = new List<WorkflowEntity>()

       });
        }
    }
}