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
            Titles = ManuelMultilanguageMapper.Map(state.Titles)!,
            PublicForms = ManuelMultilanguageMapper.Map(state.PublicForms),
            //FromStates = this state's foreign relation of statestostates table
            ToStates = MapStateRouteFromEntity(state.FromStates),
            Kind = state.Kind
        };
    }

    public static State MapStateFromStateCreateDto(StateCreateDto stateDto)
    {
        State newRecord = new State
        {
            //WorkflowName = definition,
            Name = stateDto.Name,
            BaseStatus = stateDto.BaseStatus,
            CreatedAt = DateTime.UtcNow,
            CreatedByBehalfOf = Guid.NewGuid(),
            Type = stateDto.Type,
            IsPublicForm = stateDto.IsPublicForm,
            SubWorkflowName = stateDto.SubWorkflowName,
            MFAType = stateDto.MfaType,
            InitPageName = stateDto.Type == StateType.Start ? stateDto.InitPageName : string.Empty,
        };

        if (stateDto.IsPublicForm == true)
        {
            newRecord.PublicForms = ManuelMultilanguageMapper.Map(stateDto.PublicForms);
        }
        newRecord.UiForms = UiFormMapper.Map((ICollection<UiFormDto>?)stateDto.UiForms);

        newRecord.Titles = ManuelMultilanguageMapper.Map(stateDto.Titles)!;

        #region Transition props
        if (stateDto.Transition != null)
        {
            newRecord.Kind = StateKind.Transition;
            newRecord.ServiceName = stateDto.Transition.ServiceName;
            newRecord.TypeofUi = stateDto.Transition.TypeofUi;
            newRecord.transitionButtonType = stateDto.Transition.ButtonType;
            newRecord.FlowName = stateDto.Transition.Message;
            newRecord.Page = PageMapper.Map((PageCreateDto?)stateDto.Transition.Page);
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