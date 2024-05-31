using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;

namespace amorphie.workflow.core.Dtos.Transfer;

    public class TransferHistoryRequestDto:DtoSearchBase
    {
      public string? SubjectName  {get;set;}
      public string? TransferringType {get;set;}
    }
