using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NpgsqlTypes;

public class PageComponent : amorphie.core.Base.EntityBase
{
    public Page? Page { get; set; } = default!;
    public Guid? PageId { get; set; }
    public string? PageName { get; set; }
    public string componentName { get; set; } = string.Empty;

    public NpgsqlTsVector SearchVector { get; set; }
    public Transition? transition { get; set; } = default!;
    public string? transitionName { get; set; }
    public bool? visibility { get; set; } = true;
    public string? type { get; set; } = string.Empty;
    public PageComponentUiModel? uiModel { get; set; }

    public ICollection<PageComponent>? ChildComponents { get; set; } = default!;

    public PageComponent? parentComponent { get; set; } = default!;
    public Guid? parentComponentId { get; set; }
    public string? componentJson { get; set; }

}

