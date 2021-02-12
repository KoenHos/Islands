using System;
using Aruba.Core;
using Aruba.Models;
using AutoMapper;

namespace Aruba.Mapping
{
    public class ArubaMappings : Profile
    {
        public ArubaMappings()
        {
            CreateMap<Element, ElementViewModel>()
                .ForMember(e => e.ElementId, ex => ex.MapFrom(e => e.Id))
                .ReverseMap(); 
        }
    }
}
