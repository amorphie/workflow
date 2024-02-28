using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;

public class PageComponentUiModel : amorphie.core.Base.EntityBase
{
    public ICollection<Translation> buttonText { get; set; } = default!;
}
