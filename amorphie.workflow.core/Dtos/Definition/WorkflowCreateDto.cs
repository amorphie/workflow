using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos.Definition;

public record WorkflowCreateDto(string Name, List<StateCreateDto> States);
public record StateRoutesDto(string Name, List<StateRouteDto> ToStates);
public record StateRouteDto(string ToStateName, bool? IsDefault);

