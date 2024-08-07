using amorphie.core.Base;
using amorphie.workflow;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;

public static class StateModule
{
    public static void MapStateEndpoints(this WebApplication app)
    {
    app.MapPost("/workflow/saveWorkflow", SaveWorkflowAsync)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow definition.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "State" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition saved." };
                  return operation;
              });

        app.MapGet("/workflow/states/{workflowName}", GetAllStates)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Get all states for given workflow name.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 State" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

                  return operation;
              });


        app.MapGet("/workflow/states/{workflowName}/{stateName}", GetState)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Get state for given workflow name and state name.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 State" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

                  return operation;
              });



        app.MapPost("/workflow/states/{workflowName}", SaveState)
            .Produces<Response>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status422UnprocessableEntity)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Updates or creates workflow state.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 State" } };

                  operation.Parameters[0].Description = "Exact name of workflow.";

                  operation.Responses["200"] = new OpenApiResponse { Description = "State updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "State created." };
                  return operation;
              });


        app.MapPost("/workflow/states/stateroutes", SaveStateRoutes)
            .Produces<Response>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status422UnprocessableEntity)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Updates or creates state routes.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 State" } };
                  operation.Responses["200"] = new OpenApiResponse { Description = "State updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "State created." };
                  return operation;
              });
    }


    static async Task<IResult> SaveWorkflowAsync(
      [FromServices] IWorkflowService service,
      [FromBody] WorkflowCreateDto data,
      CancellationToken token
      )
    {
        var response = await service.SaveAsync(data,token);
        return ApiResult.CreateResult(response);
    }

    static async Task<IResult> GetAllStates(
      [FromRoute(Name = "workflowName")] string workflowName,
      [FromServices] IStateService service
      )
    {
        var response = await service.GetAllAsync(workflowName);
        return ApiResult.CreateResult(response);

    }

    static async Task<IResult> GetState(
      [FromRoute(Name = "workflowName")] string workflowName,
      [FromRoute(Name = "stateName")] string stateName,

      [FromServices] IStateService service
      )
    {
        var response = await service.GetAsync(workflowName, stateName);
        return ApiResult.CreateResult(response);
    }
    static async Task<IResult> SaveState(
    [FromServices] IStateService service,
    [FromRoute(Name = "workflowName")] string workflowName,
    [FromBody] StateCreateDto data,
    CancellationToken token,
    [FromHeader(Name = "Language")] string? language = "en-EN"
    )
    {
        var response = await service.SaveAsync(data, workflowName,token);
        return ApiResult.CreateResult(response);
    }

    static async Task<IResult> SaveStateRoutes(
    [FromServices] IStateService service,
    [FromBody] StateRoutesDto data
    )
    {
        var response = await service.SaveStateRoutesAsync(data);

        return ApiResult.CreateResult(response);
    }




}


