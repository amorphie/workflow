using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NJsonSchema;
namespace amorphie.workflow;
public static class SchemaValidator
{
    public static void MapSchemaValidatorEndpoints(this WebApplication app)
    {
        app.MapPost("/workflow/schema/validate/{workflowName}/{zeebeElementId}", ValidationCheckAsync)
                   .Produces<IResult>(StatusCodes.Status200OK)
                   .WithOpenApi(operation =>
                   {
                       operation.Summary = "Checks json data against the json schema that defined and stored properly";
                       operation.Tags = new List<OpenApiTag> { new() { Name = "Schema Validator" } };

                       return operation;
                   });

        app.MapPost("/workflow/schema/save/{workflowName}/{zeebeElementId}", ValidationSaveAsync)
                   .Produces<IResult>(StatusCodes.Status200OK)
                   .WithOpenApi(operation =>
                   {
                       operation.Summary = "Saves json schema if exist updates";
                       operation.Tags = new List<OpenApiTag> { new() { Name = "Schema Validator" } };

                       return operation;
                   });

    }

    static async Task<IResult> ValidationCheckAsync(
           [FromServices] WorkflowDBContext dbContext,
           [FromRoute(Name = "workflowName")] string workflowName,
           [FromRoute(Name = "zeebeElementId")] string zeebeElementId,
           [FromBody] string jsonData
       )
    {
        var jsonSchema = await dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.WorkflowName == workflowName && p.ZeebeElementId == zeebeElementId);
        if (jsonSchema == null)
        {
            return Results.NotFound("Schema data not found");
        }
        var theSchema = await JsonSchema.FromJsonAsync(jsonSchema.Schema);
        var errors = theSchema.Validate(jsonData);
        if (errors.Count == 0)
        {
            return Results.Ok();
        }
        else
        {
            return Results.Problem("Schema validation failed " + String.Join(" ", errors.Select(p => p.Property + " " + p.Kind.ToString())));
        }
    }


    static async Task<IResult> ValidationSaveAsync(
           [FromServices] WorkflowDBContext dbContext,
           [FromRoute(Name = "workflowName")] string workflowName,
           [FromRoute(Name = "zeebeElementId")] string zeebeElementId,
           [FromBody] string jsonSchema
       )
    {
        var jsonSchemaEntity = await dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.WorkflowName == workflowName && p.ZeebeElementId == zeebeElementId);
        if (jsonSchemaEntity == null)
        {
            jsonSchemaEntity = new core.Models.JsonSchema
            {
                WorkflowName = workflowName,
                ZeebeElementId = zeebeElementId,
                Schema = jsonSchema

            };
            dbContext.JsonSchemas.Add(jsonSchemaEntity);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            jsonSchemaEntity.Schema = jsonSchema;
            dbContext.JsonSchemas.Update(jsonSchemaEntity);
            await dbContext.SaveChangesAsync();
        }
        return Results.Ok();

    }
}