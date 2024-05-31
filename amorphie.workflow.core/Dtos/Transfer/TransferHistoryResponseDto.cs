using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos.Transfer;
    public class TransferHistoryResponseDto
    {
      public string? SubjectName  {get;set;}
      public string? TransferringType {get;set;}
      public DateTime? CreatedAt {get;set;}
      public DateTime? FinishedAt {get;set;}
      public string? SemVer {get;set;}
      public Guid? CreatedBy {get;set;}

    }
