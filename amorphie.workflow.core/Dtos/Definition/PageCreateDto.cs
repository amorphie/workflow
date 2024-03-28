namespace amorphie.workflow.core.Dtos.Definition;
public class PageCreateDto
{
    public PageOperationType Operation { get; set; }
    public PageType Type { get; set; }
    public MultilanguageText? PageRoute { get; set; }
    public int? Timeout { get; set; }
}

