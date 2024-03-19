using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models;

namespace amorphie.workflow.core.Mapper;
public class UiFormMapper
{

    public static List<UiFormDto>? Map(ICollection<UiForm>? uiForms)
    {
        if (uiForms == null) return null;
        return uiForms.Select(p => Map(p)).ToList();
    }

    public static UiFormDto Map(UiForm uiForm)
    {
        return new UiFormDto
        {
            typeofUi = uiForm.TypeofUiEnum,
            navigationType = uiForm.Navigation,
            forms = uiForm.Forms?.Select(f => new Dtos.MultilanguageText(f.Language, f.Label)).ToArray()
        };
    }

    public static List<UiForm>? Map(ICollection<UiFormDto>? uiForms)
    {
        if (uiForms == null) return null;
        return uiForms.Select(p => Map(p)).ToList();
    }

    public static UiForm Map(UiFormDto uiFormDto)
    {
        return new UiForm
        {
            TypeofUiEnum = uiFormDto.typeofUi,
            Navigation = uiFormDto.navigationType,
            Forms = ManuelMultilanguageMapper.Map(uiFormDto.forms)
        };
    }


}