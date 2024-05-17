using System.Text.Json;
using amorphie.workflow.core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using NJsonSchema.Validation;
namespace amorphie.workflow.service.Filters;
public class InstanceSchemaValidationFilter : IEndpointFilter
{
    protected readonly ILogger _logger;
    protected readonly WorkflowDBContext _dbContext;

    public InstanceSchemaValidationFilter(ILoggerFactory loggerFactory, WorkflowDBContext dbContext)
    {
        _logger = loggerFactory.CreateLogger<InstanceSchemaValidationFilter>();
        _dbContext = dbContext;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next)
    {
        var modelName = GetModelName(efiContext);
        return await CheckSchema(efiContext, next, modelName);
    }

    protected async ValueTask<object?> CheckSchema(EndpointFilterInvocationContext efiContext, EndpointFilterDelegate next, string? modelName)
    {
        dynamic model = efiContext.Arguments[0];
        if (!string.IsNullOrEmpty(modelName))
        {
            var jsonSchemaEntity = await _dbContext.JsonSchemas.FirstOrDefaultAsync(p => p.SubjectName == modelName);
            if (jsonSchemaEntity != null)
            {
                //Schema validation
                var theSchema = await JsonSchema.FromJsonAsync(jsonSchemaEntity.Schema);
                var jsonString = JsonSerializer.Serialize(model);
                ICollection<ValidationError> errors = theSchema.Validate(jsonString);
                if (errors.Count > 0)
                {
                    var errorModel = errors.ToDto();
                    return Results.Extensions.ValidationError(errorModel);
                }
                var filterResponseResult = await FilterHelper.FilterResponseAsync(model, theSchema);
                efiContext.Arguments[0] = filterResponseResult;
            }
        }
        return await next(efiContext);
    }
    protected virtual string? GetModelName(EndpointFilterInvocationContext efiContext)
    {
        return efiContext.Arguments[1]?.ToString();
    }
}