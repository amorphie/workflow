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
        app.MapPost("/tasks/{taskId}/type/{type}", CompleteTask)
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
            DateTime now=DateTime.UtcNow;
            var taskList = await context.HumanTasks.Where(w => (w.Assignee == Assignee||(w.ClaimBy==Assignee&&w.ClaimDueDate>=now)) && w.Status != HumanTaskStatus.Completed
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
                Type = s.Type,
                ClaimBy=s.ClaimBy,
                ClaimDueDate=s.ClaimDueDate
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
       [FromQuery(Name = "instanceId")] string? instanceId,
            [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
    )
    {
        try
        {
            DateTime now=DateTime.UtcNow;
            HumanTaskStatus? taskStatus = amorphie.workflow.core.Helper.EnumHelper.GetValueFromDescription<HumanTaskStatus>(Status);
            var taskList = await context.HumanTasks.Where(w => ((string.IsNullOrEmpty(Assignee)) || (!string.IsNullOrEmpty(Assignee) && (w.Assignee == Assignee||(w.ClaimBy==Assignee&&w.ClaimDueDate>=now))))
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
                await UpdateTask(task, data,context,token);

                return Results.Ok();
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
        }
    }
    private static async Task UpdateTask(HumanTask dbModel, HumanTask updateModel,WorkflowDBContext context, CancellationToken token)
    {
        if (updateModel.Priority != null)
        {
            dbModel.Priority = updateModel.Priority;
        }
         if ((dbModel.ClaimBy ==null||(dbModel.ClaimDueDate!=null&&dbModel.ClaimDueDate<=DateTime.UtcNow))&&updateModel.ClaimBy!=null)
        {
            dbModel.ClaimBy = updateModel.ClaimBy;
            if(updateModel.ClaimDueDate==null)
            {
                dbModel.ClaimDueDate=DateTime.UtcNow.AddDays(3);
            }
            if(updateModel.ClaimDueDate!=null)
            {
                dbModel.ClaimDueDate=updateModel.ClaimDueDate;
            }
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
        await context.SaveChangesAsync(token);
    }

    async static ValueTask<IResult> CompleteTask(
 [FromHeader(Name = "user_reference")] string? user,
   [FromServices] WorkflowDBContext context,
   [FromServices] IZeebeCommandService zeebeCommandService,
    [FromRoute(Name = "taskId")] Guid? taskId,
    [FromRoute(Name = "type")] string type,
    [FromBody] dynamic data,
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

                await SendZeebeMessage(context,data, transitionName, task.InstanceId, sendZeebe, zeebeCommandService, token);
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
    private static async Task SendZeebeMessage(WorkflowDBContext context,dynamic data, string transitionName, Guid? InstanceId, bool sendZeebe,
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
                dynamic targetObject = new ExpandoObject();
                targetObject.Data = data;
                targetObject.TriggeredBy = Guid.NewGuid();
                targetObject.TriggeredByBehalfOf = Guid.NewGuid();

                string updateName = deleteUnAllowedCharecters(transitionName);
                variables.Add($"TRX-{transitionName}", targetObject);
                variables.Add($"TRX{updateName}", targetObject);
                await zeebeCommandService.PublishMessage(core.Constants.HumanTaskZeebeCommand.humanTaskMessage, variables, instance.Id.ToString());
            }

        }
    }
      private static string deleteUnAllowedCharecters(string transitionName)
    {
        return System.Text.RegularExpressions.Regex.Replace(transitionName, "[^A-Za-z0-9]", "", System.Text.RegularExpressions.RegexOptions.Compiled);
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
