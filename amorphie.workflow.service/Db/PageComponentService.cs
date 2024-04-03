using amorphie.core.Base;
using Microsoft.EntityFrameworkCore;
using amorphie.core.Identity;
using Serilog;

namespace amorphie.workflow.service.Db;
public class PageComponentService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<PageComponent> _dbSet;
    private readonly IBBTIdentity _bbtIdentity;

    public PageComponentService(WorkflowDBContext dbContext, IBBTIdentity bbtIdentity)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<PageComponent>();
        this._bbtIdentity = bbtIdentity;
    }
    public async Task<Response> InsertOrUpdateAsync(DtoPageComponents dto, CancellationToken cancellationToken)
    {
        string json = string.Empty;
        try
        {
            json = System.Text.Json.JsonSerializer.Serialize(dto.componentJson);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Serialization error. PageName {pageName}", dto.pageName!);
            return Response.Error("Component json could not be serialized");
        }
        PageComponent? existingPageComponent = await _dbSet.FirstOrDefaultAsync(f => f.PageName == dto.pageName, cancellationToken);
        if (existingPageComponent == null)
        {
            PageComponent add = new PageComponent()
            {

                PageName = dto.pageName!,
                ComponentJson = json,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _bbtIdentity.UserId.Value,
                CreatedByBehalfOf = _bbtIdentity.BehalfOfId.Value,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = _bbtIdentity.UserId.Value,
                ModifiedByBehalfOf = _bbtIdentity.BehalfOfId.Value

            };
            await _dbContext.PageComponents.AddAsync(add, cancellationToken);
        }
        else
        {
            existingPageComponent.ComponentJson = json;
            existingPageComponent.ModifiedAt = DateTime.UtcNow;
            existingPageComponent.ModifiedBy = _bbtIdentity.UserId.Value;
            existingPageComponent.ModifiedByBehalfOf = _bbtIdentity.BehalfOfId.Value;
        }
        return Response.Success("");
    }

}

