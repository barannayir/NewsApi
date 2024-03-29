﻿using AutoMapper;
using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Entities.Abstract;
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
                return new SuccessResult(true, LogMessage<User>.Add);
            }
            else
                return new ErrorResult(false, LogMessage<User>.AddError);
        }

        public IResult Delete(User user)
        {
            var isExsist = _userRepository.Get(n => n.Id == user.Id);
            if (isExsist != null)
            {
                _userRepository.Delete(user);
                return new SuccessResult(true, LogMessage<User>.Delete);
            }
            else
                return new ErrorResult(false, LogMessage<User>.DeleteError);
        }

        //public IDataResult<List<User>> GetAll()
        //{
        //    var users = _userRepository.GetAll();
        //    return new SuccessDataResult<List<User>>(true, "", users);
        //    //var users = _userRepository.GetAll();
        //    //var userDtos = _mapper.Map<UserDto>(users);
        //    //return new SuccessDataResult<List<UserDto>>(true, "", users);
        //}

        public IDataResult<List<UserDto>> GetAll()
        {
            var users = _userRepository.GetAll();
            var userDtos = _mapper.Map<List<UserDto>>(users);

            return new SuccessDataResult<List<UserDto>>(true, LogMessage<User>.GetAll, userDtos);
        }

        public IDataResult<UserDto> GetByUserId(int userId)
        {
            var user = _userRepository.Get(n => n.Id == userId);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessDataResult<UserDto>(true, LogMessage<User>.Get, userDto);
            }
            else
                return new ErrorDataResult<UserDto>(false, LogMessage<User>.GetError, null);
        }

        public IDataResult<UserDto> GetByUserName(string userName)
        {
            var user = _userRepository.Get(n => n.UserName == userName);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessDataResult<UserDto>(true, LogMessage<User>.Get, userDto);
            }
            else
                return new ErrorDataResult<UserDto>(false, LogMessage<User>.GetError, null);
        }

        public IResult Update(User user)
        {
            var isExsist = _userRepository.Get(n => n.Id == user.Id);
            if (isExsist != null)
            {
                _userRepository.Update(user);
                return new SuccessResult(true, LogMessage<User>.Update);
            }
            else
                return new ErrorResult(false, LogMessage<User>.UpdateError);
        }
    }
}
