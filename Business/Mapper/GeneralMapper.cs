using AutoMapper;
using Core.Services.Security.Hash;
using Entities.Abstract;
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

            //CreateMap<UserLoginDto, User>();
            //CreateMap<UserSignUpDto, User>().ForMember(dest => dest.PasswordSalt, opt=> opt.Ignore()).ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UserSignUpDto, User>()
              .ForMember(x => x.PasswordSalt, x => x.Ignore())
              .ForMember(x => x.PasswordHash, x => x.Ignore())
              .AfterMap((dto, user) =>
              {
                  HashService.CreateHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                  user.PasswordHash = passwordHash;
                  user.PasswordSalt = passwordSalt;
              });

            CreateMap<User, UserSignUpDto>();


            CreateMap<UserDto, User>().ForMember(dest => dest.PasswordSalt, opt => opt.Ignore()).ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserDto>();
        }
    }
}
