using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using amorphie.workflow.core.Models.SemanticVersion;
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
          CreateMap<PageComponent, Dtos.DtoPageComponentWithVersion>().ConstructUsing(x => new Dtos.DtoPageComponentWithVersion()
        {
            pageName = x.PageName,
            componentJson = x.ComponentJson == null ? new { } : ConvertToDynamic(x.ComponentJson),
            semVer=x.SemVer

        }).ReverseMap();
         CreateMap<SemanticVersion, Dtos.DtoPageComponentWithVersion>().ConstructUsing(x => new Dtos.DtoPageComponentWithVersion()
        {
            pageName = x.SubjectName,
            componentJson = x.JsonBody == null ? new { } : ConvertToDynamic(x.JsonBody),
            semVer=x.SemVer

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
            dynamic test= JsonSerializer.Deserialize<dynamic>(str, new JsonSerializerOptions
            {
                MaxDepth = 256
            }) ?? new { };
            return test;
        }
        catch (Exception ex)
        {
            return new { };
        }
    }

}
