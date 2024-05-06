using amorphie.workflow.core.Dtos.Schema;
using NJsonSchema.Validation;
namespace amorphie.workflow.service.Filters;
public static class ValidationErrorExtension
{
    public static List<ValidationErrorDto> ToDto(this ICollection<ValidationError> errors)
    {
        List<ValidationErrorDto> errorDictionary = new List<ValidationErrorDto>();

        foreach (var error in errors)
        {
            if (error is MultiTypeValidationError multiError)
            {
                var key = multiError.Path ?? multiError.Kind.ToString();

                errorDictionary.Add(new ValidationErrorDto { Key = key, Errors = SetErrors(multiError.Errors, key) });
            }
            else if (error is ChildSchemaValidationError childError)
            {
                var key = childError.Path ?? childError.Kind.ToString();
                errorDictionary.Add(new ValidationErrorDto { Key = key, Errors = SetErrors(childError.Errors, key) });

            }
            else
            {
                var validationErrors = new List<string>
                {
                    error.Kind.ToString()
                };
                errorDictionary.Add(new ValidationErrorDto { Key = error.Path ?? error.Kind.ToString(), Errors = validationErrors });
            }

        }

        return errorDictionary;
    }

    private static List<string> SetErrors(IReadOnlyDictionary<NJsonSchema.JsonSchema, ICollection<ValidationError>> errors, string path)
    {
        var validationErrors = new List<string>();
        foreach (var error in errors)
        {
            foreach (var validationError in error.Value)
            {
                var validationErrorPath = validationError.Path != path ? validationError.Path : "";
                validationErrors.Add($"{validationErrorPath} {validationError.Kind}");
            }
        }
        return validationErrors;
    }
    private static List<string> SetErrors(IReadOnlyDictionary<NJsonSchema.JsonObjectType, ICollection<ValidationError>> errors, string path)
    {
        var validationErrors = new List<string>();
        foreach (var error in errors)
        {
            foreach (var validationError in error.Value)
            {
                var validationErrorPath = validationError.Path != path ? validationError.Path : "";
                validationErrors.Add($"{validationErrorPath} {validationError.Kind}");
            }
        }
        return validationErrors;
    }
}
