using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;




// public  record DtoPageComponents(string? pageRoute, DtoComponent[] components);
// public record DtoComponent(string componentName,string type,bool visibility,string? transitionName,PageComponentUiModel? uiModel);
public class DtoPageComponents : DtoBase
{
    public List<DtoComponent>? components { get; set; }
    public string? pageRoute { get; set; }
}
public class DtoComponent 
{
    public DtoPageComponentUiModel? uiModel { get; set; }
    public string? componentName { get; set; }
    public string? transitionName { get; set; }
    public bool? visibility { get; set; }
    public string? type { get; set; }
    public string? componentJson { get; set; }
    public List<DtoComponent>? childComponents { get; set; }
}
public class DtoPageComponentUiModel
{
    public amorphie.workflow.core.Dtos.MultilanguageText buttonText { get; set; }
}
public class PageComponentSearch : DtoSearchBase
{

}