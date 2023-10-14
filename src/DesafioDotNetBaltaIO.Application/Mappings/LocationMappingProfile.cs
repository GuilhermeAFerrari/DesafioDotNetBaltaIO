using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Application.Mappings
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<LocationDTO, Location>().ReverseMap();
        }
    }
}
