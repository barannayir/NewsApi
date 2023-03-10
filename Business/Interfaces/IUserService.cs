using Core.Services.Results.Interfaces;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<UserDto> GetByUserName(string userName);
        IDataResult<UserDto> GetByUserId(int userId);
        IDataResult<List<UserDto>> GetAll();
    }
}
