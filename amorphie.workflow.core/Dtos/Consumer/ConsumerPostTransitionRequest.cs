namespace amorphie.workflow.core.Dtos.Consumer;
public record ConsumerPostTransitionRequest
{
    public dynamic EntityData { get; set; } = default!;
    public dynamic? FormData { get; set; }
    public dynamic? AdditionalData { get; set; }
    public bool GetSignalRHub { get; set; }
    public dynamic? RouteData { get; set; }
    public dynamic? QueryData { get; set; }
    public string? SetStateVia { get; set; }
}