using AutoMapper;
using HRTool.Models.DTOs;
using HRTool.Models.Entities;

namespace HRTool.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();  
            CreateMap<User, UpdateUserDto>().ReverseMap();  
            CreateMap<Vacation, RequestVacationDto>().ReverseMap();
            CreateMap<Vacation, VacationDto>().ReverseMap();    
        }
    }
}
