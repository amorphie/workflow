using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;

namespace amorphie.workflow.core.Mapper;
public class TrxMapperLegacy
{

    public static List<TransitionCreateDtoLegacy> MapStateCreateDtoListFromStateList(ICollection<Transition> transitions)
    {
        return transitions.Select(p => MapStateCreateDtoFromState(p)).ToList();
    }

    public static TransitionCreateDtoLegacy MapStateCreateDtoFromState(Transition transition)
    {
        return new TransitionCreateDtoLegacy
        {
            Name = transition.Name,
            ToState = transition.ToStateName,
            FromState = transition.FromStateName,
            ServiceName = transition.ServiceName,
            Message = transition.FlowName,
            Gateway = transition.Flow?.Gateway,
            //Forms = transition.Forms?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList(),
            UiForms =UiFormMapper.Map(transition.UiForms),
            Titles = transition.Titles?.Select(t => new core.Dtos.MultilanguageText(t.Language, t.Label)).ToList(),
            Page = PageMapper.Map(transition.Page)
        };
    }


}