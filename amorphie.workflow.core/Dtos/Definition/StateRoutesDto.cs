namespace amorphie.workflow.core.Dtos.Definition;

public record StateRoutesDto(string Name, List<StateRouteDto> ToStates);
public record StateRouteDto(string ToStateName, bool? IsDefault);

