namespace amorphie.workflow.redisconsumer.StreamExporters;
    public interface IExporter
{
    Task Attach(CancellationToken cancellationToken);
}

