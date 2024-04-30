
using System.Text.Json.Nodes;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NJsonSchema;
namespace amorphie.workflow.Modules;

public static class SchemaValidator
{
    public static void MapSchemaValidatorEndpoints(this WebApplication app)
    {
        app.MapPost("/schema/validate/{subjectName}", ValidationCheckAsync)
                   .Produces<IResult>(StatusCodes.Status200OK)
                   .WithOpenApi(operation =>
                   {
                       operation.Summary = "Checks json data against the json schema that defined and stored properly";
                       operation.Tags = new List<OpenApiTag> { new() { Name = "Schema Validator" } };

                       return operation;
                   });

        app.MapPost("/schema/save", ValidationSaveAsync)
                   .Produces<IResult>(StatusCodes.Status200OK)
                   .WithOpenApi(operation =>
                   {
                       operation.Summary = "Saves json schema if exist updates";
                       operation.Tags = new List<OpenApiTag> { new() { Name = "Schema Validator" } };

                       return operation;
                   });

        app.MapPost("/schema/generate", (Delegate)GenerateSchemaAsync)
                     .Produces<IResult>(StatusCodes.Status200OK)
                    .WithOpenApi(operation =>
                    {
                        operation.Summary = "Generates a json schema blueprint for given object";
                        operation.Tags = new List<OpenApiTag> { new() { Name = "Schema Validator" } };

                        return operation;
                    });

    }

    static async Task<IResult> ValidationCheckAsync(
           [FromServices] WorkflowDBContext dbContext,
           [FromRoute(Name = "subjectName")] string subjectName,
           [FromBody] string jsonData
       )
    {
        var jsonSchema = await dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.SubjectName == subjectName);
        if (jsonSchema == null)
        {
            return Results.NotFound("Schema data not found");
        }
        var theSchema = await JsonSchema.FromJsonAsync(jsonSchema.Schema);
        var jsonString = jsonData.ToString();
        var errors = theSchema.Validate(jsonString);
        if (errors.Count == 0)
        {
            return Results.Ok();
        }
        else
        {
            return Results.Problem("Schema validation failed " + String.Join(" ", errors.Select(p => p.Property + " " + p.Kind.ToString())));
        }
    }


    static async Task<IResult> ValidationSaveAsync([FromBody] JsonSchemaSaveDto schemaDto, [FromServices] WorkflowDBContext dbContext)
    {
        var jsonSchemaEntity = await dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.SubjectName == schemaDto.SubjectName);
        var serializedJsonSchema = System.Text.Json.JsonSerializer.Serialize(schemaDto.Schema);
        if (jsonSchemaEntity == null)
        {

            jsonSchemaEntity = new core.Models.JsonSchema
            {
                SubjectName = schemaDto.SubjectName,
                ObjectType = schemaDto.ObjectType,
                Schema = serializedJsonSchema

            };
            dbContext.JsonSchemas.Add(jsonSchemaEntity);
        }
        else
        {
            jsonSchemaEntity.Schema = serializedJsonSchema;
            dbContext.JsonSchemas.Update(jsonSchemaEntity);
        }
        await dbContext.SaveChangesAsync();
        return Results.Ok();

    }
    static async Task<IResult> GenerateSchemaAsync([FromBody] dynamic jsonDataDynamic)
    {

        var jsonString = jsonDataDynamic.ToString();
        var schemaFromjson = await Task.Run(() => JsonSchema.FromSampleJson(jsonString));
        var objecttedJson = System.Text.Json.JsonSerializer.Deserialize<dynamic>(schemaFromjson.ToJson());
        return Results.Ok(objecttedJson);

    }
}
