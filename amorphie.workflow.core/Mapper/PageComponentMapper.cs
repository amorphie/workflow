using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace amorphie.workflow.core.Mapper;

public class PageComponentMapper : Profile
{
    public PageComponentMapper()
    {
        CreateMap<PageComponent, DtoPageComponents>().ConstructUsing(x => new DtoPageComponents()
        {
            pageName = x.PageName,
            componentJson = x.ComponentJson == null ? new { } : ConvertToDynamic(x.ComponentJson)

        }).ReverseMap();
        CreateMap<PageComponent, dynamic>().ConstructUsing(x => ConvertToDynamic(x.ComponentJson)

        ).ReverseMap();

    }
    public dynamic ConvertToDynamic(string str)
    {
        if (string.IsNullOrEmpty(str))
            return new { };
        try
        {
            return JsonSerializer.Deserialize<dynamic>(str, new JsonSerializerOptions
            {
                MaxDepth = 256
            }) ?? new { };
        }
        catch (Exception ex)
        {
            return new { };
        }
    }

}
