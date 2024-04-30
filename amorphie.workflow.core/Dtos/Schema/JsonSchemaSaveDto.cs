namespace amorphie.workflow.core.Dtos.Schema;
public class JsonSchemaSaveDto
{
    public string SubjectName { get; set; } = default!;
    public string ObjectType { get; set; } = default!;
    public dynamic Schema { get; set; } = default!;
}
