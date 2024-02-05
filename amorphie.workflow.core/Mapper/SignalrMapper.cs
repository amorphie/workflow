using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.SignalR;
using AutoMapper;

namespace amorphie.workflow.core.Mapper
{
    public class SignalrMapper : Profile
    {
        public SignalrMapper()
        {
            CreateMap<SignalRRequest, SignalRResponsePrivate>().ReverseMap();
            CreateMap<SignalRRequest, SignalRResponsePublic>().ReverseMap();
            CreateMap<SignalRResponsePrivate, SignalRResponsePublic>().ReverseMap();
            CreateMap<SignalRResponsePrivate, SignalRData>().ForMember(x => x.Id, opt => opt.MapFrom( o => Guid.NewGuid()))
            .ForMember(x => x.InstanceId, opt => opt.MapFrom( o => o.id))
            .ReverseMap();
            CreateMap<SignalRResponsePublic,SignalRData >().ForMember(x => x.Id, opt => opt.MapFrom( o => Guid.NewGuid()))
            .ForMember(x => x.InstanceId, opt => opt.MapFrom( o => o.id))
            .ReverseMap();
        }
    }
}