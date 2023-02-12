[Flags]
public enum BaseStatusType
{
    New = 2,
    Active = 4,
    InProgress = 8,
    Passive = 16,
    All = New | Active | InProgress | Passive
}