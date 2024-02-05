using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;

namespace amorphie.workflow.core.Models.SignalR;

public class SignalRData:EntityBase
{
    public string? InstanceId { get; set; }
    public string? source { get; set; }
    public string? type { get; set; }
    public string? subject { get; set; }
    public string? data { get; set; }
    
    public string? mfatype { get; set; }
    public DateTime? time { get; set; } 
    public string? datacontenttype { get; set; } 
    public string? specversion { get; set; }
    public string? deviceId { get; set; }
    public string? userId { get; set; }
    public string? tokenId { get; set; }
    public string? requestId { get; set; }
}
