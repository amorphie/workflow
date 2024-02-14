using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;
public class SignalRResponsePublic : SignalRRequest
{
    public string mfatype { get; set; } = "public";
    public DateTime time { get; set; } = DateTime.UtcNow;
    public string datacontenttype { get; set; } = "application/json";
    public string specversion { get; set; } = "v1.0";
    public string deviceId { get; set; }

}
public class SignalRResponsePrivate : SignalRResponsePublic
{
    public SignalRResponsePrivate()
    {
        mfatype = "private";
    }
    
    public string userId { get; set; }
}
