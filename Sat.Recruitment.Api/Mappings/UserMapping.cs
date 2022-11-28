using AutoMapper;
using Sat.Recruitment.Api.Data_Access_Layer.Entities;
using Sat.Recruitment.Api.Domain_Layer.Dto;

namespace Sat.Recruitment.Api.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
          
    }
}
