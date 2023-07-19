using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Enums;

public record PostSignalRData(Guid UserId,Guid recordId,string eventInfo, Guid instanceId,string entityName, dynamic data,DateTime time,string state,string transition,StatusType baseStatus,PostPageSignalRData? page);
public record PostPageSignalRData(string operation,string type, amorphie.core.Base.MultilanguageText? pageRoute,int? timeout);
