using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}