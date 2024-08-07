using amorphie.core.Extension;
using amorphie.core.Identity;
using amorphie.core.Module.minimal_api;
using amorphie.workflow.service.Db;
using amorphie.workflow.core.Dtos.Transfer;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semver;
using amorphie.workflow.core.Models.SignalR;
namespace amorphie.workflow.Modules;

public class PageComponentModule : BaseBBTRoute<DtoPageComponents, PageComponent, WorkflowDBContext>
{

    public PageComponentModule(WebApplication app) : base(app)
    {
    }

    public override string[]? PropertyCheckList => new[] { "componentJson" };

    public override string? UrlFragment => "pageComponent";
    public override void AddRoutes(RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapPost("/", UpsertMethodWithVersion);
        routeGroupBuilder.MapGet("search", getAllPageComponentFullTextSearch);
        routeGroupBuilder.MapGet("search/names", getAllPageComponentNameFullTextSearch);
        routeGroupBuilder.MapGet("/page/{pageName}", getPageComponentByPageName);
        routeGroupBuilder.MapGet("/getAllPagesInWorkflow", GetAllPages);
    }

    async ValueTask<IResult> getAllPageComponentFullTextSearch(
        [FromServices] WorkflowDBContext context,
       [AsParameters] PageComponentSearch dataSearch,
        CancellationToken cancellationToken
   )
    {
        var query = context!.PageComponents!
            .Skip(dataSearch.Page * dataSearch.PageSize)
            .Take(dataSearch.PageSize);
        if (!string.IsNullOrEmpty(dataSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", dataSearch.Keyword)));
        }

        var securityQuestions = await query.ToListAsync(cancellationToken);

        if (securityQuestions.Any())
        {
            var response = securityQuestions.Select(x => ObjectMapper.Mapper.Map<DtoPageComponents>(x));
            return Results.Ok(response);
        }

        return Results.NoContent();
    }

    async ValueTask<IResult> getAllPageComponentNameFullTextSearch(
        [FromServices] WorkflowDBContext context,
       [AsParameters] PageComponentSearch dataSearch,
        CancellationToken cancellationToken
   )
    {
        var query = context!.PageComponents!.AsQueryable();
        query = await query.Sort<PageComponent>(dataSearch.SortColumn ?? "PageName", dataSearch.SortDirection);
        query = query.Skip(dataSearch.Page * dataSearch.PageSize)
        .Take(dataSearch.PageSize);


        if (!string.IsNullOrEmpty(dataSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", dataSearch.Keyword)));
        }

        var pageComponents = await query.Select(p => new SelectDto { Name = p.PageName }).ToListAsync(cancellationToken);

        if (pageComponents.Any())
        {
            return Results.Ok(pageComponents);
        }

        return Results.NoContent();
    }
    async ValueTask<IResult> getPageComponentByPageName(
        [FromServices] WorkflowDBContext context,
         [FromRoute(Name = "pageName")] string pageName,
        CancellationToken cancellationToken
   )
    {
        var query = await context!.PageComponents!.FirstOrDefaultAsync(f => f.PageName == pageName, cancellationToken);
        if (query != null)
            return Results.Ok(ObjectMapper.Mapper.Map<dynamic>(query));
        return Results.NoContent();
    }

    protected async ValueTask<IResult> UpsertMethodWithVersion(
         [FromServices] IMapper mapper,
         [FromServices] VersionService versionService,
         [FromServices] IValidator<PageComponent> validator,
         [FromServices] WorkflowDBContext context,
         [FromServices] IBBTIdentity bbtIdentity,
         [FromBody] DtoPageComponents data,
         CancellationToken token
         )
    {
        try
        {
            string json = string.Empty;
            try
            {
                json = System.Text.Json.JsonSerializer.Serialize(data.componentJson, new System.Text.Json.JsonSerializerOptions
                {
                    MaxDepth = 256
                });
            }
            catch (Exception)
            {
                json = string.Empty;
            }
            PageComponent? existingPageComponent = await context.PageComponents.FirstOrDefaultAsync(f => f.PageName == data.pageName, token);
            if (existingPageComponent == null)
            {
                PageComponent add = new PageComponent()
                {

                    PageName = data.pageName,
                    ComponentJson = json,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = bbtIdentity.UserId.Value,
                    CreatedByBehalfOf = bbtIdentity.BehalfOfId.Value,
                    ModifiedAt = DateTime.UtcNow,
                    ModifiedBy = bbtIdentity.UserId.Value,
                    ModifiedByBehalfOf = bbtIdentity.BehalfOfId.Value,
                    SemVer = new SemVersion(1, 0, 0).ToString()
                };
                await context.PageComponents.AddAsync(add, token);
                await context.SaveChangesAsync(token);
                await versionService.SaveVersionPageComponent(data.pageName!, add.SemVer, token);
                return Results.Created($"/{add.Id}", mapper.Map<DtoPageComponents>(add));
            }

            existingPageComponent.ComponentJson = json;
            existingPageComponent.ModifiedAt = DateTime.UtcNow;
            existingPageComponent.ModifiedBy = bbtIdentity.UserId.Value;
            existingPageComponent.ModifiedByBehalfOf = bbtIdentity.BehalfOfId.Value;
            if (string.IsNullOrEmpty(existingPageComponent.SemVer))
            {
                existingPageComponent.SemVer = new SemVersion(1, 0, 0).ToString();
            }
            SemVersion version = SemVersion.Parse(existingPageComponent.SemVer, SemVersionStyles.Any);
            version = version.WithPatch(version.Patch + 1);
            existingPageComponent.SemVer = version.ToString();
            await context.SaveChangesAsync(token);
            await versionService.SaveVersionPageComponent(existingPageComponent.PageName, existingPageComponent.SemVer, token);
            return Results.Ok();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    protected async ValueTask<IResult> GetAllPages(
         [FromServices] IMapper mapper,
         [FromServices] WorkflowDBContext context,
         CancellationToken token
         )
    {
        try
        {
            core.Dtos.AllPagesResponse response = new core.Dtos.AllPagesResponse();

            List<dynamic> allPages = new List<dynamic>();
            var query = await context!.PageComponents!.ToListAsync(token);
            if (query != null)
            {
                foreach (var item in query)
                {
                    try
                    {
                        response.PageComponentList.Add(ObjectMapper.Mapper.Map<dynamic>(item));
                    }
                    catch (Exception)
                    {
                        response.PageComponentList.Add(new
                        {
                            PageName = item.PageName,
                            ComponentJson = "It is not Json"
                        });
                    }
                }
            }
            response.TemplateList = await context!.UiForms.SelectMany(s => s.Forms).Select(s => s.Label).Distinct().ToListAsync(token);
            var stateList = await context!.States.Where(w => w.AllowedSuffix != null && w.AllowedSuffix.Any()).ToListAsync(token);
            foreach (State suffixState in stateList)
            {
                foreach (string suffix in suffixState.AllowedSuffix)
                {
                    string suffixWith = "-" + suffix;
                    response.TemplateList.AddRange(await context!.UiForms.Where(s => s.StateName == suffixState.Name)
                    .SelectMany(s => s.Forms).Select(s => s.Label + suffixWith).Distinct().ToListAsync(token));
                }
            }
            response.TemplateList.AddRange(await context!.SignalRResponses.Where(s => s.pageUrl != null).Select(s => s.pageUrl).ToListAsync(token));
            response.TemplateList = response.TemplateList.Distinct().ToList();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }



}