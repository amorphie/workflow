using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using amorphie.core.Base;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models.SemanticVersion;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace amorphie.workflow.service.Db
{
    public class VersionService
    {
        private readonly WorkflowDBContext _dbContext;
         private readonly IServiceProvider _serviceProvider;
         protected Lazy<TransferService> _transferService;

        public VersionService(WorkflowDBContext dbContext, IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
            _dbContext = dbContext;
            _transferService = new Lazy<TransferService>(() =>
                     _serviceProvider.GetRequiredService<TransferService>());
        }
        public async Task<Response<SemanticVersion>> SaveVersionWorkflow(string workflowName, string version,CancellationToken cancellationToken)
        {
            Response<WorkflowCreateDto> dto=await _transferService.Value.GetDefinitionBulkAsync(workflowName,cancellationToken);
            SemanticVersion semanticVersion=new SemanticVersion(){
                SubjectName=workflowName,
                JsonBody=JsonSerializer.Serialize(dto.Data),
                SemVer=version,
                VersionTable=VersionTable.Workflow,
                CreatedAt=DateTime.UtcNow
            };
            return await SaveVersion(semanticVersion,cancellationToken);
        }
        public async Task<Response<SemanticVersion>> SaveVersionPageComponent(string pageName, string version,CancellationToken cancellationToken)
        {
            PageComponent? query = await _dbContext.PageComponents.FirstOrDefaultAsync(f => f.PageName == pageName, cancellationToken);
            string pageComponent=string.Empty;
            SemanticVersion semanticVersion=new SemanticVersion(){
                SubjectName=pageName,
                JsonBody=JsonSerializer.Serialize(query),
                SemVer=version,
                VersionTable=VersionTable.Workflow,
                CreatedAt=DateTime.UtcNow
            };
            return await SaveVersion(semanticVersion,cancellationToken);
        }
        private async Task<Response<SemanticVersion>> SaveVersion(SemanticVersion semanticVersion,CancellationToken cancellationToken)
        {
            await _dbContext.SemanticVersions.AddAsync(semanticVersion,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
              return new Response<SemanticVersion>
            {
                Data =semanticVersion,
                Result = new Result(amorphie.core.Enums.Status.Success, "")
            };
        }
    }
}