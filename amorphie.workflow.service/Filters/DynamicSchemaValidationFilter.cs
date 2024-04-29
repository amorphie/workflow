using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace amorphie.workflow.service.Filters;
public class DynamicSchemaValidationFilter : BaseSchemaValidationFilter
{
    public DynamicSchemaValidationFilter(ILoggerFactory loggerFactory, WorkflowDBContext dbContext): base(loggerFactory, dbContext)
    {
    }
}