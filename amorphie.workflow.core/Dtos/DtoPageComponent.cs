using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;
public class DtoPageComponents : DtoEntityBaseWithOutId
{
    public string? pageName { get; set; }
    public dynamic? componentJson { get; set; } = default!;
}

public class PageComponentSearch : DtoSearchBase
{

}