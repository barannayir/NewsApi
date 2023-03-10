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
            CreateMap<UserSignUpDto, User>();
        }
    }
}
