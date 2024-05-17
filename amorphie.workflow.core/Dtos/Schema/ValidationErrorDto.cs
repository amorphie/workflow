namespace amorphie.workflow.core.Dtos.Schema;
public class ValidationErrorDto
{
    public string Key { get; set; } = default!;
    public List<string> Errors { get; set; } = [];

}
