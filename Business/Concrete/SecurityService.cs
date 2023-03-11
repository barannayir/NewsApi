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
                return new ErrorDataResult<JwtToken>(false, LogMessage<User>.LoginError, null);
            if (!HashService.VerifyPassword(userSignInModel.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<JwtToken>(false, LogMessage<User>.PasswordError, null);
            var token = CreateAccessToken(user);
            return new SuccessDataResult<JwtToken>(true, LogMessage<User>.Login, token);
            
        }

        public IDataResult<User> SignUp(UserSignUpDto userSignUpModel)
        {
            var isUserExist = _userRepository.GetByUserName(userSignUpModel.UserName);
            if (isUserExist != null)
                return new ErrorDataResult<User>(false, LogMessage<User>.UserExists, null);
            var user = _mapper.Map<User>(userSignUpModel);
            _userRepository.Add(user);
            return new SuccessDataResult<User>(true, LogMessage<User>.Register, user);
        }
        public JwtToken CreateAccessToken(User user)
        {
            return _jwtService.GenerateJwtToken(user);
        }
    }
}
