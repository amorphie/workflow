using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace amorphie.workflow.service.Db
{
    public class HumanTaskService
    {
        private readonly WorkflowDBContext _context;
        private readonly IConfiguration _configuration;
        public HumanTaskService(WorkflowDBContext _dbContext,IConfiguration configuration)
        {
            _context = _dbContext;
            _configuration=configuration;
        }
        public async  Task< List<core.Dtos.HumanTasks.HumanTaskDto?>> HumanTaskWithView(List<core.Dtos.HumanTasks.HumanTaskDto?>? taskList,
     string? language, string? role, string? type, CancellationToken token)
    {
        var templateURL = _configuration["templateEngineUrl"]!.ToString();
        List<core.Dtos.HumanTasks.HumanTaskDto?> responseList = new List<core.Dtos.HumanTasks.HumanTaskDto?>();
        foreach (var item in taskList)
        {
            if(!string.IsNullOrEmpty(item.AppTransitionName))
            {
                item.ApproveView = await TransitionModel(item.AppTransitionName, language, role, type, templateURL, token);
            }
            if(!string.IsNullOrEmpty(item.DenyTransitionName))
            {
                item.RejectView = await TransitionModel( item.DenyTransitionName, language, role, type, templateURL, token);
            }
            InstanceTransition? lastTransition = await _context.InstanceTransitions.OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(f => f.InstanceId == item.InstanceId, token);
            if (lastTransition != null)
            {
                try
                {
                    item.lastEntityData = System.Text.Json.JsonSerializer.Deserialize<dynamic>(lastTransition.EntityData);
                    item.lastAdditionalData = System.Text.Json.JsonSerializer.Deserialize<dynamic>(lastTransition.AdditionalData);
                }
                catch(Exception)
                {
                    item.lastEntityData =new {};
                    item.lastAdditionalData =new {};
                }
            }
            responseList.Add(item);
        }
        return responseList;
        // if (responseList.Any())
        // {
        //     return responseList;
        // }
        // return Results.NoContent();
    }
    private async  Task<ViewTransitionModel?> TransitionModel( string transitionName, string? language, string? role, string? type, string templateURL, CancellationToken token)
    {
          // (( string.IsNullOrEmpty(role)&& f.Role != null&&role == f.Role) || (string.IsNullOrEmpty(f.Role))) &&
          //&& f.TypeofUiEnum.ToString().ToLower() == type
        UiForm? appUiForm = await _context.UiForms.Include(t => t.Forms)
        .Where(f=> f.TypeofUiEnum!=null && f.Forms != null && f.Forms.Any() && f.TransitionName == transitionName)
        .FirstOrDefaultAsync(token);
        if (appUiForm != null)
        {
            amorphie.core.Base.Translation? translation = appUiForm.Forms.Where(s => s.Language == language).FirstOrDefault();
            if (translation == null)
            {
                translation = appUiForm.Forms.FirstOrDefault();
            }

            return new ViewTransitionModel()
            {
                name = translation.Label,
                type = appUiForm.TypeofUiEnum.ToString(),
                language = translation.Language,
                navigation = appUiForm.Navigation.ToString(),
                body = amorphie.workflow.core.Helper.TemplateEngineHelper.TemplateEngineForm(translation.Label, string.Empty, templateURL, string.Empty, 1)
            };

        }
        return null;
    }
   
    }
}