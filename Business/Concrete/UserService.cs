using Business.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(true, "", _userRepository.GetAll());
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
