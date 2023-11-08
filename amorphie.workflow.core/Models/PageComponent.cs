using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NpgsqlTypes;

public class PageComponent : amorphie.core.Base.EntityBase
{

    public string PageName { get; set; } = string.Empty;

    public NpgsqlTsVector SearchVector { get; set; }

    public string? ComponentJson { get; set; }

}

