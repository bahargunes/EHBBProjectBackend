using AutoMapper;
using ProjectBackend.Business.DTOs;
using ProjectBackend.Data.Entities;

namespace ProjectBackend.Business.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Platform, PlatformDTO>().ReverseMap();
            CreateMap<PlatformDTO, Platform>()
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.PlatformId, opt => opt.Ignore());

            // Laser
            CreateMap<Laser, LaserDTO>()
                .ForMember(dest => dest.LaserModes, opt => opt.MapFrom(src => src.LaserModes))
                .ReverseMap();
            CreateMap<LaserMode, LaserModeDTO>().ReverseMap();

            // Emitter
            CreateMap<Emitter, EmitterDTO>()
                .ForMember(dest => dest.Modes, opt => opt.MapFrom(src => src.Modes))
                .ReverseMap(); 
            CreateMap<EmitterMode, EmitterModeDTO>().ReverseMap();


        }
    }
}
