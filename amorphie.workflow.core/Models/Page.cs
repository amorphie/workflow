using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Page: amorphie.core.Base.EntityBase
{
    public PageOperationType Operation { get; set; }
    public PageType Type { get; set; }
    public ICollection<amorphie.core.Base.Translation>? Pages { get; set; } = default!;
    public int? Timeout { get; set; }

}
