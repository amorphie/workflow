
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
            /*s.Name,
                  s.Titles.FirstOrDefault()!.Label,
                  s.Tags!,
                  s.Entities.Select(e => new GetWorkflowEntity(
           e.Name, e.InclusiveWorkflows == null ? false : true, e.IsStateManager,
           new StatusType[]{
          e.AvailableInStatus
           }
      )).ToArray(),
                  s.RecordId == null ? string.Empty : s.RecordId.ToString()*/
            CreateMap<Workflow, GetWorkflowDefinition>()
      .ConstructUsing(x => new GetWorkflowDefinition(x.Name, x.Titles.FirstOrDefault().Label, x.Tags, x.Entities.Select(e => new GetWorkflowEntity(
     e.Name, e.InclusiveWorkflows == null ? false : true, e.IsStateManager,
     new amorphie.core.Enums.StatusType[]{
        e.AvailableInStatus
     }
)).ToArray(), x.RecordId == null ? string.Empty : x.RecordId.ToString())
      );
        }
    }
}