using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using amorphie.core.Identity;
using amorphie.core.Module.minimal_api;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
namespace amorphie.workflow.Modules;

    public class PageComponentModule : BaseBBTRoute<DtoPageComponents, PageComponent, WorkflowDBContext>
    {
        public PageComponentModule(WebApplication app) : base(app)
        {
        }

        public override string[]? PropertyCheckList => new [] { "type", "componentName", "visibility", "transitionName" };

        public override string? UrlFragment => "pageComponent";
        public override void AddRoutes(RouteGroupBuilder routeGroupBuilder)
        {
            base.AddRoutes(routeGroupBuilder);

            routeGroupBuilder.MapGet("search", getAllPageComponentFullTextSearch);
        }

        async ValueTask<IResult> getAllPageComponentFullTextSearch(
            [FromServices] WorkflowDBContext context,
           [AsParameters] PageComponentSearch dataSearch
       )
        {
            var query = context!.PageComponents!
            .Include(s => s.ChildComponents)
            .Include(s => s.uiModel)
            .Include(s => s.transition)
                .Skip(dataSearch.Page * dataSearch.PageSize)
                .Take(dataSearch.PageSize);


            if (!string.IsNullOrEmpty(dataSearch.Keyword))
            {
                query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", dataSearch.Keyword)));
            }

            var securityQuestions = query.ToList();

            if (securityQuestions.Count() > 0)
            {
                var response = securityQuestions.Select(x => ObjectMapper.Mapper.Map<DtoPageComponents>(x)).ToList();
                return Results.Ok(response);
            }

            return Results.NoContent();
        }

        protected override async ValueTask<IResult> UpsertMethod(
            [FromServices] IMapper mapper,
            [FromServices] IValidator<PageComponent> validator,
            [FromServices] WorkflowDBContext context,
            [FromServices] IBBTIdentity bbtIdentity,
            [FromBody] DtoPageComponents data,
            HttpContext httpContext,
            CancellationToken token
            )
        {
            try
            {

                Page? Page = await context.Pages!.Include(s => s.Pages).Include(s => s.PagesComponents)
                      .FirstOrDefaultAsync(w => w.Pages.Any(a => a.Label == data.pageRoute), token)
                      ;
                if (Page == null)
                {
                    Results.Problem("Not Found " + data.pageRoute, null, 404); ;
                }
                else
                {
                    bool saveChanges = false;

                    var insertList = data.components.Where(w => Page.PagesComponents!.All(a => a.componentName 
                    != w.componentName)).Select(s => new PageComponent
                    {
                        PageId = Page.Id,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = bbtIdentity.UserId.Value,
                        CreatedByBehalfOf = bbtIdentity.BehalfOfId.Value,
                        PageName = data.pageRoute,
                        componentName = s.componentName,
                        transitionName = s.transitionName,
                        visibility = s.visibility,
                        type = s.type,
                        componentJson=s.componentJson,
                        uiModel =s.uiModel?.buttonText!=null? new PageComponentUiModel(){
                            buttonText=new List<amorphie.core.Base.Translation>(){new amorphie.core.Base.Translation(){
                                Language=s.uiModel.buttonText.language,
                                Label=s.uiModel.buttonText.label,
                            }
                            }
                            
                        }:null,
                        ChildComponents = s.childComponents.Any() ? pageComponentsMap(Page.Id, data.pageRoute, s.childComponents, bbtIdentity, token) : null
                    });



                    var pageComponentUpdate = data.components.Where(w => Page.PagesComponents!.Any(a => a.componentName == w.componentName));

                    foreach (var pageComponent in pageComponentUpdate)
                    {
                        bool IsChange = false;
                        object? dbValue;
                        object? dtoValue;
                        var dbModel = Page.PagesComponents.FirstOrDefault(f => f.componentName == pageComponent.componentName);
                        foreach (string property in PropertyCheckList)
                        {

                            dbValue = typeof(PageComponent).GetProperties().First(p => p.Name.Equals(property)).GetValue(dbModel);
                            dtoValue = typeof(DtoComponent).GetProperties().First(p => p.Name.Equals(property)).GetValue(pageComponent);

                            if (dbValue != null && !dbValue.Equals(dtoValue))
                            {
                                typeof(PageComponent).GetProperties().First(p => p.Name.Equals(property)).SetValue(dbModel, dtoValue);
                                IsChange = true;
                            }
                        }
                        if (IsChange)
                        {
                            dbModel.ModifiedAt = DateTime.UtcNow;
                            dbModel.ModifiedBy = bbtIdentity.UserId.Value;
                            dbModel.ModifiedByBehalfOf = bbtIdentity.BehalfOfId.Value;

                            saveChanges = true;

                        }
                    }
                   
                         if (insertList.Any())
                    {
                        await context.PageComponents.AddRangeAsync(insertList, token);
                        saveChanges = true;
                    }
                     if (saveChanges)
                     {
                        await context.SaveChangesAsync(token);
                          return Results.Ok();
                     }
                        else{
                             return Results.NoContent();
                        }
                }
            }
            catch (Exception ex)
            {
                 return Results.Problem("Unexcepted error:"+ex.ToString());
            }
              return Results.NoContent();
        }
        private List<PageComponent> pageComponentsMap(Guid? PageId, string pageRoute, List<DtoComponent> dtoComponents, IBBTIdentity identity, CancellationToken token)
        {
            List<PageComponent> list = dtoComponents.Select(s => new PageComponent
            {
                PageId = PageId,
                PageName = pageRoute,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = identity.UserId.Value,
                CreatedByBehalfOf = identity.BehalfOfId.Value,
                componentName = s.componentName!,
                transitionName = s.transitionName,
                visibility = s.visibility,
                componentJson=s.componentJson,
                type = s.type,
               uiModel =s.uiModel?.buttonText!=null? new PageComponentUiModel(){
                            buttonText=new List<amorphie.core.Base.Translation>(){new amorphie.core.Base.Translation(){
                                Language=s.uiModel.buttonText.language,
                                Label=s.uiModel.buttonText.label,
                            }
                            }
                            
                        }:null,
                ChildComponents = s.childComponents.Any() ? pageComponentsMap(PageId, pageRoute, s.childComponents, identity, token) : null

            }).ToList();
            return list;
        }


    }
