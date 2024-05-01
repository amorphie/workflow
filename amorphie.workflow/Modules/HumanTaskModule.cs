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
        app.MapPost("/tasks/{taskId}/complete", CompleteTask)
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
[FromQuery(Name = "assignee")] string? Assignee,
CancellationToken token
)
    {
        try
        {
            var taskList = await context.HumanTasks.Where(w => w.Assignee == Assignee&&w.Status!=HumanTaskStatus.Completed).ToListAsync(token);
            if (taskList.Any())
            {
                return Results.Ok(taskList);
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
     [FromQuery(Name = "assignee")] string? Assignee,
      [FromRoute(Name = "status")] string? Status,
    CancellationToken token
    )
    {
        try
        {



            var taskList = await context.HumanTasks.Where(w => ((string.IsNullOrEmpty(Assignee)) || (!string.IsNullOrEmpty(Assignee) && w.Assignee == Assignee))
            && amorphie.workflow.core.Helper.EnumHelper.GetDescription<HumanTaskStatus>(w.Status.GetValueOrDefault()) == Status).ToListAsync(token);
            if (taskList.Any())
            {
                return Results.Ok(taskList);
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
 [FromBody] HumanTask data,
 [FromHeader(Name = "user_reference")] string user,
   [FromServices] WorkflowDBContext context,
   [FromServices] IZeebeCommandService zeebeCommandService,
     [FromRoute(Name = "taskId")] Guid? taskId,
   CancellationToken token
   )
    {
        try
        {
            
            var task = await context.HumanTasks.Where(w => w.TaskId == taskId).FirstOrDefaultAsync(token);
            if (task != null)
            {
                if(task.Type==HumanTaskType.Assigned&&user!=task.Assignee)
                {
                    return Results.Problem(user+" can not complete this task!");
                }
                task.Status = HumanTaskStatus.Completed;
                UpdateTask(task, data);
                await context.SaveChangesAsync(token);
                Instance? instance=await context.Instances.Where(w => w.Id == task.InstanceId).FirstOrDefaultAsync(token);
                if(instance!=null&&!string.IsNullOrEmpty(task.HumanTaskAppTransition))
                {   
                  await  zeebeCommandService.PublishMessage(task.HumanTaskAppTransition!,new {},instance.Id.ToString());
                }
              
                return Results.Ok();
            }
            return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.Problem("Unexcepted error:" + ex.ToString());
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
            if(data.Status==null)
            {
                data.Status=HumanTaskStatus.Pending;
            }
           
            if(data.DueBy==null)
            {
                data.DueBy=DateTime.MaxValue;
            }
            data.CreatedAt=DateTime.UtcNow;
            if(data.Priority==null)
            {
                data.Priority=HumanTaskPriority.Low;
            }
            data.TaskId = Guid.NewGuid();
            if (data.Type == core.Enums.HumanTaskType.SelfSelected)
            {
                data.Assignee = string.Empty;
            }
             if(data.Type==null&&string.IsNullOrEmpty(data.Assignee))
            {
                data.Type=HumanTaskType.SelfSelected;
            }
            if(!string.IsNullOrEmpty(data.Assignee))
            {
                data.Type=HumanTaskType.Assigned;
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
