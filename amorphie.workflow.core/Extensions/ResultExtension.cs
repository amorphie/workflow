using System.Net;
using amorphie.workflow.core.Dtos.Schema;
using Microsoft.AspNetCore.Http;
namespace amorphie.workflow.core.Extensions;
public static class ResultExtension
{
    public static IResult ValidationError(this IResultExtensions resultExtensions, List<ValidationErrorDto> validationErrors)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);

        return new ValidationErrorResult(validationErrors);
    }
}

public class ValidationErrorResult : IResult
{
    private readonly List<ValidationErrorDto> _validationErrors;

    public ValidationErrorResult(List<ValidationErrorDto> validationErrors)
    {
        _validationErrors = validationErrors;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        return httpContext.Response.WriteAsJsonAsync(_validationErrors);
    }
}
