using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace amorphie.workflow.core.Mapper;

      public class PageComponentMapper : Profile
{
    public PageComponentMapper()
    {


        CreateMap<PageComponent, DtoPageComponents>().ReverseMap();

    }
}
