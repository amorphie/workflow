namespace amorphie.workflow.core.Dtos;
public class SignalRRequest
{
    public string id { get; set; }
    public string source { get; set; }
    public string type { get; set; }
    public string subject { get; set; }
    public dynamic? data { get; set; }
    public bool? routeChange { get; set; }
}
