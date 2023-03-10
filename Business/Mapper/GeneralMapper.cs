using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Mapper
{
    public class GeneralMapper : Profile
    {
        
        public GeneralMapper()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<UserSignUpDto, User>().ForMember(dest => dest.PasswordSalt, opt=> opt.Ignore()).ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserDto>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
