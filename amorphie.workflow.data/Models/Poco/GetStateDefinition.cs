
public abstract record GetStateDefinition(string name, string title, bool isFinalState, BaseStatusType baseStatus, GetTransitionDefinition[] transitions);

public record GetTransitionDefinition(string name, string title, string toState, string? form);

public record GetFSMTransitionDefinition(string name, string title, string toState, string? form) : GetTransitionDefinition(name, title, toState, form);
public record GetZeebeTransitionDefinition(string name, string title, string toState, string? form, string process, string gateway) : GetTransitionDefinition(name, title, toState, form);

