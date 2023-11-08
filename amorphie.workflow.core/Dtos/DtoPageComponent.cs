using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;
public class DtoPageComponents : DtoBase
{
    public string? pageName { get; set; }
    public string? componentJson { get; set; }
}

public class PageComponentSearch : DtoSearchBase
{

}