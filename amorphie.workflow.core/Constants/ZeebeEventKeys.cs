namespace amorphie.workflow.core.Constants;
public static class ZeebeEventKeys
{
    public const string COMPLETED = "COMPLETED";

    #region Process_Instance Stream Intents
    public const string ELEMENT_COMPLETED = "ELEMENT_COMPLETED";
    public const string ELEMENT_ACTIVATED = "ELEMENT_ACTIVATED";
    #endregion
    public const string CREATED = "CREATED";
    public const string CORRELATED = "CORRELATED";
    public const string PUBLISHED = "PUBLISHED";


    public const string ACTIVATED = "ACTIVATED";
    public const string ACTIVATE = "ACTIVATE";
}
