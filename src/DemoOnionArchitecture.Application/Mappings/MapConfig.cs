using AutoMapper;
using DemoOnionArchitecture.Application.DTOs;
using DemoOnionArchitecture.Domain.Entity;


namespace DemoOnionArchitecture.Application.Mappings
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Villa,VillaDTO>().ReverseMap();
        }
    }
}
