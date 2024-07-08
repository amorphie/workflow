using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

public class InstanceSearch : amorphie.core.Base.DtoSearchBase
{
    public GetInstanceStatusType? Status { get; set; }
    public string[]? KeywordList { get; set; }
    public string? State {get;set;}
    public string? Start {get;set;}
    public string? End {get;set;}

}
