
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace amorphie.workflow.service.Filters;
public class SchemaValidationFilter : BaseSchemaValidationFilter
{
    public SchemaValidationFilter(ILoggerFactory loggerFactory, WorkflowDBContext dbContext) : base(loggerFactory, dbContext)
    {
    }
    protected override string? GetModelName(EndpointFilterInvocationContext efiContext)
    {
        var model = efiContext.Arguments[0];
        return model?.GetType().Name;
    }
}