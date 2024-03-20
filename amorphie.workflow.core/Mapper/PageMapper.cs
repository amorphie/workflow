using amorphie.core.Base;
using amorphie.workflow.core.Dtos.Definition;

namespace amorphie.workflow.core.Mapper;
public class PageMapper
{

    public static PageCreateDto? Map(Page? page)
    {
        if (page != null)
        {
            var pageDto = new PageCreateDto
            {
                Operation = page.Operation,
                Type = page.Type,
                Timeout = page.Timeout,
                PageRoute = null
            };
            if (page.Pages != null && page.Pages.Any())
                pageDto.PageRoute = ManuelMultilanguageMapper.Map(page.Pages.First());
            return pageDto;
        }
        return null;
    }

    public static Page? Map(PageCreateDto? page)
    {
        if (page == null) return null;
        var newPage = new Page
        {
            Operation = page.Operation,
            Type = page.Type,
            Timeout = page.Timeout,
        };
        if (page.PageRoute != null)
        {
            newPage.Pages = new List<Translation>
            {
                ManuelMultilanguageMapper.Map(page.PageRoute)
            };
        }
        return newPage;
    }
}