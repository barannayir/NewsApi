using AutoMapper;
using Business.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using Core.Services.Security.Hash;
using Core.Services.Security.Jwt;
using Core.Services.Security.Jwt.Interfaces;
using DataAccess.Interfaces;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public SecurityService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public IDataResult<User> Login(UserLoginDto userSignInModel)
        {
            var user = _userRepository.GetByUserName(userSignInModel.UserName);
            if (user == null)
                return new ErrorDataResult<User>(false, "Kullanıcı bulunamadı", user);
            if (!HashService.VerifyPassword(userSignInModel.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<User>(false, "Şifre hatalı", user);
            return new SuccessDataResult<User>(true, "Giriş başarılı", user);

        }

        public IDataResult<User> SignUp(UserSignUpDto userSignUpModel, string password)
        {
            HashService.CreateHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<User>(userSignUpModel);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userRepository.Add(user);
            return new SuccessDataResult<User>(true, "", user);
        }
        public IDataResult<JwtToken> CreateAccessToken(User user)
        {
            var jwtToken = _jwtService.GenerateJwtToken(user);
            return new SuccessDataResult<JwtToken>(true,"",jwtToken);
        }
    }
}
