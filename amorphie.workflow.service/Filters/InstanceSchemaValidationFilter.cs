using System.Text.Json;
using amorphie.workflow.core.Extensions;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Http;
using NJsonSchema.Validation;
namespace amorphie.workflow.service.Filters;
public class InstanceSchemaValidationFilter : IEndpointFilter
{
    protected readonly JsonSchemaService _jsonSchemaService;

    public InstanceSchemaValidationFilter(JsonSchemaService jsonSchemaService)
    {
        _jsonSchemaService = jsonSchemaService;
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
            var jsonSchemaEntity = await _jsonSchemaService.GetNjsonSchemaAsync(modelName);
            if (jsonSchemaEntity != null)
            {
                var jsonString = JsonSerializer.Serialize(model);
                ICollection<ValidationError> errors = jsonSchemaEntity.Validate(jsonString);
                if (errors.Count > 0)
                {
                    var errorModel = errors.ToDto();
                    return Results.Extensions.ValidationError(errorModel);
                }


                // var instanceId = efiContext.Arguments[4]?.ToString();
                // var filterResponseResult = await FilterHelper.FilterAndEncryptAsync(model, theSchema, instanceId);
                // efiContext.Arguments[0] = filterResponseResult;
            }
        }
        return await next(efiContext);
    }
    protected virtual string? GetModelName(EndpointFilterInvocationContext efiContext)
    {
        return efiContext.Arguments[1]?.ToString();
    }
}