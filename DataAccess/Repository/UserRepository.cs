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
        public UserRepository(NewsDbContext context) : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
   
}
