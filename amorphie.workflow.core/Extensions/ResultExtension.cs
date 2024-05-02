using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
namespace amorphie.workflow.core.Extensions;
public static class ResultExtension
{
    public static IResult ValidationError(this IResultExtensions resultExtensions, Dictionary<string, string[]> validationErrors)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);

        return new ValidationErrorResult(validationErrors);
    }
}

public class ValidationErrorResult : IResult
{
    private readonly Dictionary<string, string[]> _validationErrors;

    public ValidationErrorResult(Dictionary<string, string[]> validationErrors)
    {
        _validationErrors = validationErrors;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

        return httpContext.Response.WriteAsJsonAsync(_validationErrors);
    }
}
