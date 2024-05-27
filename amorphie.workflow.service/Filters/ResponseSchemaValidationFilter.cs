using System.Text.Json;
using amorphie.workflow.core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using NJsonSchema.Validation;
namespace amorphie.workflow.service.Filters;
public class ResponseSchemaValidationFilter : IEndpointFilter
{
    protected readonly ILogger _logger;
    protected readonly WorkflowDBContext _dbContext;

    public ResponseSchemaValidationFilter(ILoggerFactory loggerFactory, WorkflowDBContext dbContext)
    {
        _logger = loggerFactory.CreateLogger<ResponseSchemaValidationFilter>();
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