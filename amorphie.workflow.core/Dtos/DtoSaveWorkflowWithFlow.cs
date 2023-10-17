using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;
using amorphie.workflow.core.Dtos;

public class DtoSaveWorkflowWithFlow
{
    public string? name { get; set; }
    public amorphie.workflow.core.Dtos.MultilanguageText[]? title { get; set; }
    public DtoSaveEntitiesWithFlow[]? entities { get; set; }
    public string[]? tags { get; set; }
    public WorkflowStatus status { get; set; }
    public amorphie.workflow.core.Dtos.MultilanguageText[]? historyForms { get; set; }
    public DtoSaveStatesWithFlow[]? states { get; set; }
    public DtoSaveTransitionsWithFlow[]? transitions { get; set; }

}
public class DtoSaveEntitiesWithFlow
{
    public string? name { get; set; }
    public bool allowOnlyOneActiveInstance { get; set; }
    public bool isStateManager { get; set; }
    public amorphie.core.Enums.StatusType AvailableInStatus { get; set; }
}
public class DtoSaveStatesWithFlow
{
    public string definition { get; set; }
    public string name { get; set; }
    public amorphie.core.Enums.StatusType baseStatus { get; set; }
    public StateType type { get; set; }
    public amorphie.workflow.core.Dtos.MultilanguageText[]? title { get; set; }

}
public class DtoSaveTransitionsWithFlow
{
    public amorphie.workflow.core.Dtos.MultilanguageText[]? title { get; set; }
    public string? name { get; set; }
    public string? toState { get; set; }
    public string? fromState { get; set; }
    public string? message { get; set; }
    public string? gateway { get; set; }
    public string? serviceName { get; set; }

    public PostPageDefinitionRequest[]? page { get; set; }
}

