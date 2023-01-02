
public abstract record GetStateDefinition(string name, string displayName, bool isFinalState, GetTransitionDefinition[] transitions);

public record GetTransitionDefinition(string name, string displayName, string? fromState, string toState, string? form);

public record GetFSMTransitionDefinition(string name, string displayName, string? fromState, string toState, string? form) : GetTransitionDefinition(name, displayName, fromState, toState, form);
public record GetZeebeTransitionDefinition(string name, string displayName, string? fromState, string toState, string? form, string? process, string gateway): GetTransitionDefinition(name, displayName, fromState, toState, form);

