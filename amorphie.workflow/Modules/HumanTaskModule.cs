using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using amorphie.workflow.service.Zeebe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace amorphie.workflow.Modules;

public static class TransferModule
{

    public static void MapHumanTaskModuleEndpoints(this WebApplication app)
    {


        app.MapGet("/tasks/user", GetTask)
             .Produces<HumanTask>(StatusCodes.Status200OK)
             .WithOpenApi(operation =>
             {
                 operation.Summary = "Retrieves tasks assigned to a user.";
                 operation.Tags = new List<OpenApiTag> { new() { Name = "Human Task" } };

                 return operation;
             });
        app.MapGet("/tasks/status/{status}", GetTaskByStatus)
       .Produces<HumanTask>(StatusCodes.Status200OK)
       .WithOpenApi(operation =>
       {
           operation.Summary = "Retrieves tasks by status";
           operation.Tags = new List<OpenApiTag> { new() { Name = "Human Task" } };

           return operation;
       });
        app.MapPatch("/tasks/{taskId}/status", UpdateTaskStatus)
      .Produces<HumanTask>(StatusCodes.Status200OK)
      .WithOpenApi(operation =>
      {
          operation.Summary = "Updates a task's status.";
          operation.Tags = new List<OpenApiTag> { new() { Name = "Human Task" } };

          return operation;
      });
        app.MapPost("/tasks/save", InsertTaskMethod)
       .Produces<HumanTask>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status201Created)
       .WithOpenApi(operation =>
         {
             operation.Summary = "Saves Task";
             operation.Tags = new List<OpenApiTag> { new() { Name = "Human Task" } };

             operation.Responses["200"] = new OpenApiResponse { Description = "Human task created." };
             operation.Responses["204"] = new OpenApiResponse { Description = "Human task not created." };

             return operation;
         });
        app.MapGet("/tasks/{taskId}/type/{type}", CompleteTask)
   .Produces<HumanTask>(StatusCodes.Status200OK)

   .WithOpenApi(operation =>
     {
         operation.Summary = "Marks a task as completed.";
         operation.Tags = new List<OpenApiTag> { new() { Name = "Human Task" } };

         operation.Responses["200"] = new OpenApiResponse { Description = "Task as completed" };
         return operation;
     });
    }
    async static ValueTask<IResult> GetTask(

[FromServices] WorkflowDBContext context,
[FromServices] service.Db.HumanTaskService humanTaskService,
[FromQuery(Name = "assignee")] string? Assignee,
IConfiguration configuration,
CancellationToken token,
[FromQuery] string? type,
[FromHeader(Name = "role")] string? role,
[FromHeader(Name = "Accept-Language")] string? language = "en-EN"
)
    {
        try
        {
            var taskList = await context.HumanTasks.Where(w => w.Assignee == Assignee && w.Status != HumanTaskStatus.Completed
            && w.Status != HumanTaskStatus.Denied).Select(s => new core.Dtos.HumanTasks.HumanTaskDto()
            {
                TaskId = s.TaskId,
                AppTransitionName = s.AppTransitionName,
                Assignee = s.Assignee,
                AutoTransaction = s.AutoTransaction,
                AutoTransactionTimeout = s.AutoTransactionTimeout,
                AutoTransitionName = s.AutoTransitionName,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                DenyTransitionName = s.DenyTransitionName,
                Description = s.Description,
                DueBy = s.DueBy,
                InstanceId = s.InstanceId,
                Metadata = s.Metadata,
                Name = s.Name,
                Priority = s.Priority,
                Roles = s.Roles,
                State = s.State,
                Status = s.Status,
                Type = s.Type
            }).ToListAsync(token);
            var response=await humanTaskService.HumanTaskWithView(taskList,language,role,TypeofUiEnum.FlutterWidget.ToString().ToLower(),token);
            if(response!=null)
            {
                return Results.Ok(response);
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    async static ValueTask<IResult> GetTaskByStatus(
    [FromServices] WorkflowDBContext context,
    [FromServices] service.Db.HumanTaskService humanTaskService,
     [FromQuery(Name = "assignee")] string? Assignee,
      [FromRoute(Name = "status")] string? Status,
       IConfiguration configuration,
        CancellationToken token,
       //[FromQuery] string? type,
       [FromHeader(Name = "role")] string? role,
       [FromHeader(Name = "instanceId")] string? instanceId,
            [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
    )
    {
        try
        {

            HumanTaskStatus? taskStatus = amorphie.workflow.core.Helper.EnumHelper.GetValueFromDescription<HumanTaskStatus>(Status);
            var taskList = await context.HumanTasks.Where(w => ((string.IsNullOrEmpty(Assignee)) || (!string.IsNullOrEmpty(Assignee) && w.Assignee == Assignee))
            && w.Status == taskStatus
            &&((string.IsNullOrEmpty(instanceId)) || (!string.IsNullOrEmpty(instanceId) && w.InstanceId.ToString() == instanceId))).Select(s => new core.Dtos.HumanTasks.HumanTaskDto()
            {
                TaskId = s.TaskId,
                AppTransitionName = s.AppTransitionName,
                Assignee = s.Assignee,
                AutoTransaction = s.AutoTransaction,
                AutoTransactionTimeout = s.AutoTransactionTimeout,
                AutoTransitionName = s.AutoTransitionName,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                DenyTransitionName = s.DenyTransitionName,
                Description = s.Description,
                DueBy = s.DueBy,
                InstanceId = s.InstanceId,
                Metadata = s.Metadata,
                Name = s.Name,
                Priority = s.Priority,
                Roles = s.Roles,
                State = s.State,
                Status = s.Status,
                
                Type = s.Type
            }).ToListAsync(token);
            var response=await humanTaskService.HumanTaskWithView(taskList,language,role,TypeofUiEnum.FlutterWidget.ToString().ToLower(),token);
            if(response!=null)
            {
                return Results.Ok(response);
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    private async static Task<IResult> HumanTaskWithView(WorkflowDBContext context, IConfiguration configuration, List<core.Dtos.HumanTasks.HumanTaskDto?>? taskList,
     string? language, string? role, string? type, CancellationToken token)
    {
        var templateURL = configuration["templateEngineUrl"]!.ToString();
        List<core.Dtos.HumanTasks.HumanTaskDto?> responseList = new List<core.Dtos.HumanTasks.HumanTaskDto?>();
        foreach (var item in taskList)
        {
            if(!string.IsNullOrEmpty(item.AppTransitionName))
            {
                item.ApproveView = await TransitionModel(context, item.AppTransitionName, language, role, type, templateURL, token);
            }
            if(!string.IsNullOrEmpty(item.DenyTransitionName))
            {
                item.RejectView = await TransitionModel(context, item.DenyTransitionName, language, role, type, templateURL, token);
            }
            InstanceTransition? lastTransition = await context.InstanceTransitions.OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(f => f.InstanceId == item.InstanceId, token);
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
        if (responseList.Any())
        {
            return Results.Ok(responseList);
        }
        return Results.NoContent();
    }
    private async static Task<ViewTransitionModel?> TransitionModel(WorkflowDBContext context, string transitionName, string? language, string? role, string? type, string templateURL, CancellationToken token)
    {
          // (( string.IsNullOrEmpty(role)&& f.Role != null&&role == f.Role) || (string.IsNullOrEmpty(f.Role))) &&
          //&& f.TypeofUiEnum.ToString().ToLower() == type
        UiForm? appUiForm = await context.UiForms.Include(t => t.Forms)
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
    async static ValueTask<IResult> UpdateTaskStatus(

    [FromServices] WorkflowDBContext context,
    [FromBody] HumanTask data,
      [FromRoute(Name = "taskId")] Guid? taskId,
    CancellationToken token
    )
    {
        try
        {

            HumanTask? task = await context.HumanTasks.Where(w => w.TaskId == taskId).FirstOrDefaultAsync(token);
            if (task != null)
            {
                UpdateTask(task, data);
                await context.SaveChangesAsync(token);

                return Results.Ok();
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    private static void UpdateTask(HumanTask dbModel, HumanTask updateModel)
    {
        if (updateModel.Priority != null)
        {
            dbModel.Priority = updateModel.Priority;
        }
        if (!string.IsNullOrEmpty(updateModel.Assignee))
        {
            dbModel.Assignee = updateModel.Assignee;
        }
        if (updateModel.Type != null)
        {
            dbModel.Type = updateModel.Type;
        }
        if (!string.IsNullOrEmpty(updateModel.Description))
        {
            dbModel.Description = updateModel.Description;
        }
        if (updateModel.DueBy != DateTime.MaxValue)
        {
            dbModel.DueBy = updateModel.DueBy;
        }
        dbModel.Name = updateModel.Name;
    }

    async static ValueTask<IResult> CompleteTask(
 [FromHeader(Name = "user_reference")] string? user,
   [FromServices] WorkflowDBContext context,
   [FromServices] IZeebeCommandService zeebeCommandService,
    [FromRoute(Name = "taskId")] Guid? taskId,
    [FromRoute(Name = "type")] string type,
   CancellationToken token
   )
    {
        try
        {
            List<string> typeList = new List<string>(){
amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.Complete),
amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.Deny),
amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.AutoTrigger)
            };
            if (!typeList.Exists(a => a == type.ToLower()))
            {
                return Results.NotFound();
            }
            var task = await context.HumanTasks.Where(w => w.TaskId == taskId).FirstOrDefaultAsync(token);
            if (task != null)
            {
                string transitionName = task.AutoTransitionName != null ? task.AutoTransitionName : string.Empty;
                bool sendZeebe = false;
                if (amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.AutoTrigger) != type.ToLower()
                && task.Type == HumanTaskType.Assigned && user != task.Assignee)
                {
                    return Results.Problem(user + " can not " + type + " this task!");
                }
                task.Status = HumanTaskStatus.Completed;
                if (amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.Deny) == type)
                {
                    task.Status = HumanTaskStatus.Denied;
                    transitionName = task.DenyTransitionName!;
                    sendZeebe = true;
                }
                if (amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskCompleteType>(HumanTaskCompleteType.Complete) == type)
                {
                    transitionName = task.AppTransitionName!;
                    sendZeebe = true;
                }

                await SendZeebeMessage(context, transitionName, task.InstanceId, sendZeebe, zeebeCommandService, token);
                await context.SaveChangesAsync(token);
                return Results.Ok(task);
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    private static async Task SendZeebeMessage(WorkflowDBContext context, string transitionName, Guid? InstanceId, bool sendZeebe,
    IZeebeCommandService zeebeCommandService, CancellationToken token)
    {
        Instance? instance = await context.Instances.Where(w => w.Id == InstanceId).FirstOrDefaultAsync(token);
        if (instance != null)
        {
            dynamic variables = new Dictionary<string, dynamic>();
            variables.Add($"humanTaskMessageValue", transitionName);
            variables.Add($"LastTransition", transitionName);
            Transition? transition = await context.Transitions.FirstOrDefaultAsync(f => f.Name == transitionName, token);
            InstanceTransition instanceTransition = new InstanceTransition()
            {
                InstanceId = instance.Id,
                FromStateName = instance.StateName,
                ToStateName = transition!.ToStateName!,
                EntityData = "{}",
                HeadersData = "{}",
                AdditionalData = "{}",
                TransitionName = transitionName,
                StartedAt = DateTime.UtcNow
            };
            await context.InstanceTransitions.AddAsync(instanceTransition, token);
            if (sendZeebe)
            {
                await zeebeCommandService.PublishMessage(core.Constants.HumanTaskZeebeCommand.humanTaskMessage, variables, instance.Id.ToString());
            }

        }
    }
    async static ValueTask<IResult> InsertTaskMethod(

[FromServices] WorkflowDBContext context,
[FromBody] HumanTask data,
CancellationToken token
)
    {
        try
        {
            if (data.Status == null)
            {
                data.Status = HumanTaskStatus.Pending;
            }

            if (data.DueBy == null)
            {
                data.DueBy = DateTime.MaxValue;
            }
            data.CreatedAt = DateTime.UtcNow;
            if (data.Priority == null)
            {
                data.Priority = HumanTaskPriority.Low;
            }
            data.TaskId = Guid.NewGuid();
            if (data.Type == core.Enums.HumanTaskType.SelfSelected)
            {
                data.Assignee = string.Empty;
            }
            if (data.Type == null && string.IsNullOrEmpty(data.Assignee))
            {
                data.Type = HumanTaskType.SelfSelected;
            }
            if (!string.IsNullOrEmpty(data.Assignee))
            {
                data.Type = HumanTaskType.Assigned;
            }


            await context.HumanTasks.AddAsync(data, token);


            await context.SaveChangesAsync(token);
            return Results.Ok(data);

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }


}
