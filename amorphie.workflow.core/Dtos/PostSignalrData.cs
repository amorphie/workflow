using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Enums;

public record PostSignalRData(Guid UserId,string eventInfo, Guid instanceId, dynamic data,DateTime time,string state,string transition,StatusType baseStatus,PostPageDefinitionRequest? page);
