using amorphie.workflow.core.Dtos;

public static class RegisteredClients
{
    public static Dictionary<long, WorkerBodyHeaders> ClientList = new Dictionary<long, WorkerBodyHeaders>();
    public static Dictionary<long, Guid> ActiveInstanceList = new Dictionary<long, Guid>();
}