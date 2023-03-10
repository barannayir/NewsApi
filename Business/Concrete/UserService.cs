using AutoMapper;
using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ILoggerService loggerService, IMapper mapper)
        {
            _userRepository = userRepository;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public IResult Add(User user)
        {
            var isExsist = _userRepository.Get(n => n.UserName == user.UserName);
            if (isExsist == null)
            {
                _userRepository.Add(user);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IResult Delete(User user)
        {
            var isExsist = _userRepository.Get(n => n.Id == user.Id);
            if (isExsist != null)
            {
                _userRepository.Delete(user);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IDataResult<List<UserDto>> GetAll()
        {
            //var users = _userRepository.GetAll();
            //return new SuccessDataResult<List<User>>(true, "", users);
            var users = _userRepository.GetAll();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return new SuccessDataResult<List<UserDto>>(true, "", userDtos);
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            var user = _userRepository.Get(n => n.Id == userId);
            if (user != null)
                return new SuccessDataResult<User>(true, "", user);
            else
                return new ErrorDataResult<User>(false, "", user);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            var user = _userRepository.Get(n => n.UserName == userName);
            if (user != null)
                return new SuccessDataResult<User>(true, "", user);
            else
                return new ErrorDataResult<User>(false, "", user);
        }

        public IResult Update(User user)
        {
            var isExsist = _userRepository.Get(n => n.Id == user.Id);
            if (isExsist != null)
            {
                _userRepository.Update(user);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }
    }
}
