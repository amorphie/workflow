using System.Dynamic;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Consumer;
using amorphie.workflow.core.Models;
namespace amorphie.workflow.service.Variable;
public class VariableService
{
    public static dynamic CreateMessageVariables(Instance instance, ConsumerPostTransitionRequest request, Dictionary<string, string>? headers)
    {
        dynamic variables = new Dictionary<string, dynamic>();

        variables.Add("EntityName", instance.WorkflowName);
        variables.Add("RecordId", instance.Id);
        variables.Add("InstanceId", instance.Id);
        variables.Add("LastTransition", instance.StateName);

        dynamic targetObject = new ExpandoObject();
        targetObject.Data = request;
        targetObject.TriggeredBy = instance.ModifiedBy;
        targetObject.TriggeredByBehalfOf = instance.CreatedByBehalfOf;

        string updateName = instance.StateName.DeleteUnAllowedCharecters();
        variables.Add($"TRX{updateName}", targetObject);

        variables.Add($"Headers", headers);
        return variables;
    }

    //Üsttekinde headers var ve param farklı
    public static dynamic CreateMessageVariables(Instance instance, string lastTransition, WorkerBodyTrxDatas _data)
    {
        dynamic variables = new Dictionary<string, dynamic>();

        variables.Add("EntityName", instance.EntityName);
        variables.Add("RecordId", instance.RecordId);
        variables.Add("InstanceId", instance.Id);
        variables.Add("LastTransition", lastTransition);
        dynamic targetObject = new System.Dynamic.ExpandoObject();
        targetObject.Data = _data.Data;
        targetObject.TriggeredBy = instance.CreatedBy;
        targetObject.TriggeredByBehalfOf = instance.CreatedByBehalfOf;
        string updateName = instance.StateName.DeleteUnAllowedCharecters();
        variables.Add($"TRX-{instance.StateName}", targetObject);
        variables.Add($"TRX{updateName}", targetObject);
        return variables;
    }
}

