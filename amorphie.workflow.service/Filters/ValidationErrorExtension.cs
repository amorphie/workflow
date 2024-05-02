using NJsonSchema.Validation;
namespace amorphie.workflow.service.Filters;
public static class ValidationErrorExtension
{
    public static Dictionary<string, string[]> ToDict(this ICollection<ValidationError> errors)
    {
        Dictionary<string, string[]> errorDictionary = new Dictionary<string, string[]>();

        foreach (var error in errors)
        {
            if (error is MultiTypeValidationError multiError)
            {
                var key = multiError.Path ?? multiError.Kind.ToString();

                errorDictionary.Add(key, SetErrors(multiError.Errors, key));
            }
            else if (error is ChildSchemaValidationError childError)
            {
                var key = childError.Path ?? childError.Kind.ToString();
                errorDictionary.Add(key, SetErrors(childError.Errors, key));

            }
            else
            {
                var validationErrors = new List<string>
                {
                    error.Kind.ToString()
                };
                errorDictionary.Add(error.Path ?? error.Kind.ToString(), validationErrors.ToArray());
            }

        }

        return errorDictionary;
    }
    private static string[] SetErrors(IReadOnlyDictionary<NJsonSchema.JsonSchema, ICollection<ValidationError>> errors, string path)
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
        return validationErrors.ToArray();
    }
    private static string[] SetErrors(IReadOnlyDictionary<NJsonSchema.JsonObjectType, ICollection<ValidationError>> errors, string path)
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
        return validationErrors.ToArray();
    }
}
