using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.core.Enums;
namespace amorphie.workflow.core.Mapper;
public class StateMapperLegacy
{

    public static List<StateCreateDtoLegacy> Map(ICollection<State> states)
    {
        return states.Select(p => Map(p)).ToList();
    }

    public static StateCreateDtoLegacy Map(State state)
    {
        return new StateCreateDtoLegacy
        {
            Name = state.Name,
            BaseStatus = state.BaseStatus,
            InitPageName = state.InitPageName,
            IsPublicForm = state.IsPublicForm,
            MfaType = state.MFAType,
            Type = state.Type,
            Transitions = TrxMapperLegacy.MapStateCreateDtoListFromStateList(state.Transitions),
            UiForms = UiFormMapper.Map(state.UiForms),
            SubWorkflowName = state.SubWorkflowName,
            Titles = state.Titles?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList(),
            PublicForms = state.PublicForms?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList()
        };
    }

    public static State Map(StateCreateDtoLegacy stateDto)
    {
        var data = stateDto;
        State newRecord = new State
        {
            Name = data.Name,
            BaseStatus = data.BaseStatus,
            CreatedAt = DateTime.UtcNow,
            CreatedByBehalfOf = Guid.NewGuid(),
            Type = data.Type,
            IsPublicForm = data.IsPublicForm,
            SubWorkflowName = data.SubWorkflowName,
            MFAType = data.MfaType,
            InitPageName = data.Type == StateType.Start ? data.InitPageName : string.Empty,
        };
        //Todo: Remove public forms

        if (data.IsPublicForm == true && data.PublicForms.Any())
        {
            newRecord.PublicForms =ManuelMultilanguageMapper.Map(data.PublicForms);
        }
        newRecord.UiForms = UiFormMapper.Map(data.UiForms);

        newRecord.Titles = ManuelMultilanguageMapper.Map(data.Titles);


        newRecord.Kind = StateKind.SimpleState;

        return newRecord;
    }


}