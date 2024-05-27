using amorphie.core.Base;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.core.Dtos.Definition;

namespace amorphie.workflow.service.Db;
public class WorkflowService : IWorkflowService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<Workflow> _dbSet;
    private readonly IStateService _stateService;
    private readonly VersionService _versionService;
    public WorkflowService(WorkflowDBContext dbContext, IStateService stateService,VersionService versionService)
    {
        _versionService=versionService;
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Workflow>();
        _stateService = stateService;
    }

    public async Task<Response> SaveAsync(WorkflowCreateDto data, CancellationToken token)
    {
        var existingRecord = await _dbSet
            .Include(s => s.Entities)
            .Include(s => s.HistoryForms)
            .FirstOrDefaultAsync(w => w.Name == data.Name);

        Semver.SemVersion version = new Semver.SemVersion(1, 0, 0);
        if (existingRecord == null)
        {
            await Insert(data);
        }
        else
        {
            Update(data, existingRecord);
        }
        if (await _dbContext!.SaveChangesAsync() > 0 )
        {
            if(existingRecord != null)
            {
                if (string.IsNullOrEmpty(existingRecord!.SemVer))
            {
                existingRecord.SemVer = version.ToString();
            } 
           version = Semver.SemVersion.Parse(existingRecord.SemVer, Semver.SemVersionStyles.Any);


            version = version.WithMinor(version.Minor + 1);
            existingRecord.SemVer = version.ToString();
            await _dbContext!.SaveChangesAsync();
            }
             await _versionService.SaveVersionWorkflow(data.Name,version.ToString(),token);
            
        }
        //Save States and Trxs
        if (data.NewStates != null && data.NewStates.Count > 0)
        {
            await _stateService.SaveBulkAsync(data.NewStates, data.Name, token);
        }
        else if (data.States != null)
        {
            await _stateService.LegacySaveBulkAsync(data);
        }
        return Response.Success("");
    }

    public async Task<Response<Workflow>> GetAsync(string workflowName)
    {
        var workFlows = await _dbSet
            .Include(s => s.Entities)
            .Include(s => s.States)
            .Where(w => w.Name == workflowName)
            .FirstOrDefaultAsync();

        if (workFlows == null)
        {
            return new Response<Workflow>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Not found")
            };
        }
        else
        {
            return new Response<Workflow>
            {
                Data = workFlows,
                Result = new Result(amorphie.core.Enums.Status.Success, "")
            };
        }

    }


    public async Task Insert(WorkflowCreateDto data)
    {
        //Why is this bussines for

        bool recordIdNull = false;
        if (data.RecordId == Guid.Empty)
        {
            recordIdNull = true;
        }

        Workflow newWorkflow = new Workflow
        {
            WorkflowStatus = data.Status,
            Name = data.Name,
            Tags = data.Tags,
            Titles = data.Titles.Select(s => new Translation
            {
                Label = s.label,
                Language = s.language
            }).ToList(),
            IsForbiddenData = data.IsForbiddenData,
            Entities = InsertEntityList(data),
            RecordId = recordIdNull ? null : data.RecordId,
            CreatedAt = DateTime.UtcNow,
            SemVer = new Semver.SemVersion(1, 0, 0).ToString(),
            CreatedByBehalfOf = Guid.NewGuid(),
            HistoryForms = data.HistoryForms != null && data.HistoryForms.Count() > 0 ? data.HistoryForms.Select(s => new Translation
            {
                Language = s.language,
                Label = s.label
            }).ToList() : new List<Translation>()
        };
        await _dbContext.Workflows!.AddAsync(newWorkflow);
        
        // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.

    }
    public void Update(WorkflowCreateDto data, Workflow existingRecord)
    {
        //Why is this bussines for
        bool recordIdNull = false;
        if (data.RecordId == Guid.Empty)
        {
            recordIdNull = true;
        }
        if (existingRecord.Tags != data.Tags || existingRecord.WorkflowStatus != data.Status)
        {
            existingRecord.ModifiedAt = DateTime.UtcNow;
            existingRecord.Tags = data.Tags;
            existingRecord.WorkflowStatus = data.Status;
        }
        if (!recordIdNull && existingRecord.RecordId != data.RecordId)
        {
            existingRecord.ModifiedAt = DateTime.UtcNow;
            existingRecord.RecordId = data.RecordId;
        }
        if (data.IsForbiddenData != null && data.IsForbiddenData != existingRecord.IsForbiddenData)
        {
            existingRecord.IsForbiddenData = data.IsForbiddenData;
            existingRecord.ModifiedAt = DateTime.UtcNow;
        }
        if ((existingRecord.HistoryForms == null || existingRecord.HistoryForms.Count == 0) && (data.HistoryForms != null && data.HistoryForms.Count() > 0))
        {
            existingRecord.HistoryForms = data.HistoryForms.Select(s => new Translation
            {
                Id = Guid.NewGuid(),
                Label = s.label,
                Language = s.language
            }).ToList();
        }
        else if (data.HistoryForms != null && data.HistoryForms.Count() > 0)
        {
            foreach (var historyFormTranslantion in data.HistoryForms)
            {
                if (existingRecord.HistoryForms == null)
                {
                    existingRecord.HistoryForms = new List<Translation>();
                    existingRecord.HistoryForms.Add(new Translation()
                    {
                        Label = historyFormTranslantion.label,
                        Language = historyFormTranslantion.language
                    });
                }
                else
                {
                    Translation? translation = existingRecord.HistoryForms.FirstOrDefault(f => f.Language == historyFormTranslantion.language);
                    if (translation != null && translation.Label != historyFormTranslantion.label)
                    {
                        translation.Label = historyFormTranslantion.label;
                    }
                    else if (translation == null)
                    {
                        existingRecord.HistoryForms.Add(new Translation()
                        {
                            Label = historyFormTranslantion.label,
                            Language = historyFormTranslantion.language
                        });
                    }
                }
            }
        }
        foreach (var req in data.Entities)
        {
            WorkflowEntity? existingEntity = existingRecord.Entities!.FirstOrDefault(db => db.Name == req.Name);
            //Kayıdı olmayan entitylerin eklenmesi
            if (existingEntity == null)
            {
                _dbContext.WorkflowEntities!.Add(new WorkflowEntity
                {
                    Name = req.Name,
                    //  IsExclusive = req.IsExclusive,
                    IsStateManager = req.IsStateManager,
                    AvailableInStatus = req.AvailableInStatus,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByBehalfOf = Guid.NewGuid(),
                });
            }
            else if (existingEntity.IsStateManager != req.IsStateManager
            //  || existingEntity.IsExclusive != req.IsExclusive
            || existingEntity.AvailableInStatus != req.AvailableInStatus)
            {
                //Kayıdı olup update edilmesi gereken entityler 
                // existingEntity.IsExclusive = req.IsExclusive;
                existingEntity.IsStateManager = req.IsStateManager;
                existingEntity.AvailableInStatus = req.AvailableInStatus;
            }
        }
    }

    private List<WorkflowEntity> InsertEntityList(WorkflowCreateDto data)
    {
        List<WorkflowEntity> wfEntity = data.Entities.Select(s => new WorkflowEntity()
        {
            AvailableInStatus = s.AvailableInStatus,
            //  IsExclusive = item.isExclusive,
            IsStateManager = s.IsStateManager,
            Name = s.Name,
            WorkflowName = data.Name
        }).ToList();
        return wfEntity;
    }
}
