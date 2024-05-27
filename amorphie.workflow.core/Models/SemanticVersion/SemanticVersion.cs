using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models.SemanticVersion;
public class SemanticVersion : EntityBase
{
    public string SubjectName { get; set; } = default!;
    public string JsonBody { get; set; } = default!;
    public string SemVer { get; set; } = default!;
    public VersionTable VersionTable  { get; set; } = default!;
     
}
