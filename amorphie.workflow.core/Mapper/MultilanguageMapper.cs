using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using MultilanguageText = amorphie.workflow.core.Dtos.MultilanguageText;


namespace amorphie.workflow.core.Mapper;

public class ManuelMultilanguageMapper
{
    public static List<MultilanguageText>? Map(IEnumerable<Translation>? translation)
    {
        if (translation == null) return null;
        return translation.Select(p => Map(p)).ToList();
    }
    public static MultilanguageText Map(Translation translation)
    {
        return new MultilanguageText
        (
            translation.Language,
            translation.Label
            );
    }
    public static List<Translation>? Map(IEnumerable<MultilanguageText>? multiLang)
    {
        if (multiLang == null) return null;
        return multiLang.Select(p => Map(p)).ToList();
    }
    public static Translation Map(MultilanguageText multiLang)
    {
        return new Translation
        {
            Language = multiLang.language,
            Label = multiLang.label
        };
    }
}
