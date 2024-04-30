using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NJsonSchema;
namespace amorphie.workflow.service.Filters;
public class BaseSchemaValidationFilter : IEndpointFilter
{
    protected readonly ILogger _logger;
    protected readonly WorkflowDBContext _dbContext;

    public BaseSchemaValidationFilter(ILoggerFactory loggerFactory, WorkflowDBContext dbContext)
    {
        _logger = loggerFactory.CreateLogger<SchemaValidationFilter>();
        _dbContext = dbContext;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next)
    {
        var modelName = GetModelName(efiContext);
        return await CheckSchema(efiContext, next, modelName);
    }

    protected async ValueTask<object?> CheckSchema(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next, string? modelName)
    {
        var model = efiContext.Arguments[0];
        if (!string.IsNullOrEmpty(modelName))
        {
            var jsonSchemaEntity = await _dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.SubjectName == modelName);
            if (jsonSchemaEntity != null)
            {
                //Schema validation
                var theSchema = await JsonSchema.FromJsonAsync(jsonSchemaEntity.Schema);
                var jsonString = JsonSerializer.Serialize(model);
                var errors = theSchema.Validate(jsonString);
                if (errors.Count > 0)
                {
                    return Results.Problem("Schema validation failed : " + String.Join(", ", errors.Select(p => p.ToString())));
                }
            }
        }
        return await next(efiContext);
    }
    protected virtual string? GetModelName(EndpointFilterInvocationContext efiContext)
    {
        return efiContext.Arguments[1]?.ToString();
    }
}