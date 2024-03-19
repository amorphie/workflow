using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;

namespace amorphie.workflow.core.Mapper;
public class StateMapper
{

    public static List<StateCreateDto> Map(ICollection<State> states)
    {
        return states.Select(p => Map(p)).ToList();
    }

    public static StateCreateDto Map(State state)
    {
        return new StateCreateDto
        {
            Name = state.Name,
            BaseStatus = state.BaseStatus,
            InitPageName = state.InitPageName,
            IsPublicForm = state.IsPublicForm,
            MfaType = state.MFAType,
            Type = state.Type,
            Transition = StateMapper.SetTransitionCreateDto(state),
            UiForms = UiFormMapper.Map(state.UiForms),
            SubWorkflowName = state.SubWorkflowName,
            Titles = state.Titles?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList(),
            PublicForms = state.PublicForms?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList(),
            //FromStates = this state's foreign relation of statestostates table
            ToStates = MapStateRouteFromEntity(state.FromStates),
            Kind = state.Kind
        };
    }

    public static State MapStateFromStateCreateDto(StateCreateDto stateDto)
    {
        var data = stateDto;
        State newRecord = new State
        {
            //WorkflowName = definition,
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

        if (data.IsPublicForm == true && data.PublicForms.Any())
        {
            newRecord.PublicForms = data.PublicForms.Select(s => new Translation()
            {
                Language = s.language,
                Label = s.label
            }).ToList();
        }
        newRecord.UiForms = UiFormMapper.Map(data.UiForms);

        newRecord.Titles = ManuelMultilanguageMapper.Map(data.Titles);

        #region Transition props
        if (data.Transition != null)
        {
            newRecord.Kind = StateKind.Transition;
            newRecord.ServiceName = data.Transition.ServiceName;
            newRecord.TypeofUi = data.Transition.TypeofUi;
            newRecord.transitionButtonType = data.Transition.ButtonType;
            newRecord.FlowName = data.Transition.Message;
            newRecord.Page = PageMapper.Map(data.Transition.Page);
        }
        else
        {
            newRecord.Kind = StateKind.SimpleState;
        }
        #endregion
        return newRecord;
    }

    public static TransitionCreateDto? SetTransitionCreateDto(State state)
    {
        if (state.Kind == StateKind.Transition)
            return new TransitionCreateDto
            {
                ServiceName = state.ServiceName,
                TypeofUi = state.TypeofUi,
                ButtonType = state.transitionButtonType,
                Page = PageMapper.Map(state.Page)

            };
        return null;
    }

    public static List<StateRouteDto> MapStateRouteFromEntity(ICollection<StateToState>? stateToState)
    {
        if (stateToState != null)
            return stateToState.Select(p => new StateRouteDto(p.ToStateName, p.IsDefault)).ToList();
        return new List<StateRouteDto>();
    }

}