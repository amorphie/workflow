namespace amorphie.workflow.core.Models;
public class JsonSchema : amorphie.core.Base.EntityBase
{
    public string SubjectName { get; set; } = default!;
    public string ObjectType { get; set; } = default!;

    public string Schema { get; set; } = default!;
}