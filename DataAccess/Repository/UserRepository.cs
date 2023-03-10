using Core.Services.Logs.Interfaces;
using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : GenericRepository<User, NewsDbContext>, IUserRepository
    {
        public UserRepository(NewsDbContext context, ILoggerService loggerService) : base(context, loggerService)
        {
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(n => n.UserName == userName);
        }
    }
   
}
