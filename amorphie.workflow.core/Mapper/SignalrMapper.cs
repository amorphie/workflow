using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Dtos;
using AutoMapper;

namespace amorphie.workflow.core.Mapper
{
    public class SignalrMapper : Profile
    {
        public SignalrMapper()
        {
            CreateMap<SignalRRequest, SignalRResponsePrivate>().ReverseMap();
            CreateMap<SignalRRequest, SignalRResponsePublic>().ReverseMap();
        }
    }
}