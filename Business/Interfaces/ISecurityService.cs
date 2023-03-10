using Core.Services.Results.Interfaces;
using Core.Services.Security.Jwt;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISecurityService
    {
        IDataResult<User> SignUp(UserSignUpDto userSignUpModel, string password);

        IDataResult<User> Login(UserLoginDto userSignInModel);
        IDataResult<JwtToken> CreateAccessToken(User user);


    }
}
