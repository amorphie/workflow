namespace amorphie.workflow.core.Logging;
public class LoggingOptions
{
    public const string Logging = "Logging";
    public bool LogResponse { get; set; } = false;
    public bool LogRequest { get; set; } = true;
    public string[]? SanitizeHeaderNames { get; set; }
    public string[]? SanitizeFieldNames { get; set; }
}