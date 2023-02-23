[Flags]
public enum BaseStatusType
{
    // Workflow Status
    New = 2,
    Active = 4,
    InProgress = 8,
    Passive = 16,
    
    All = New | Active | InProgress | Passive,

    // Management Status
    Completed = 32,
    LockedForFlow = 256,
}