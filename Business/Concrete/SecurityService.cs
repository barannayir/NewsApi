using AutoMapper;
using Business.Interfaces;
using Core.Services.Logs.Interfaces;
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
        private readonly ILoggerService _loggerService;

        public SecurityService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper, ILoggerService loggerService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public IDataResult<JwtToken> Login(UserLoginDto userSignInModel)
        {
            var user = _userRepository.GetByUserName(userSignInModel.UserName);
            if (user == null)
                return new ErrorDataResult<JwtToken>(false, "Kullanıcı bulunamadı", null);
            if (!HashService.VerifyPassword(userSignInModel.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<JwtToken>(false, "Şifre hatalı", null);
            var token = CreateAccessToken(user);
            return new SuccessDataResult<JwtToken>(true, "Giriş başarılı", token);
            
        }

        public IDataResult<User> SignUp(UserSignUpDto userSignUpModel)
        {
            HashService.CreateHash(userSignUpModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //var user = _mapper.Map<User>(userSignUpModel);
            var user = new User
            {
                UserName = userSignUpModel.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = userSignUpModel.Email
            };
            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;
            _userRepository.Add(user);
            return new SuccessDataResult<User>(true, "", user);
        }
        public JwtToken CreateAccessToken(User user)
        {
            return _jwtService.GenerateJwtToken(user);
        }
    }
}
