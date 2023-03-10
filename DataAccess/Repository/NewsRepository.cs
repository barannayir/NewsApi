using Core.Services.Logs.Interfaces;
using DataAccess.Data;
using DataAccess.Interfaces;
using Entities.Abstract;
using Entities.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NewsRepository : GenericRepository<News, NewsDbContext>, INewsRepository
    {
        public NewsRepository(NewsDbContext context, ILoggerService loggerService) : base(context, loggerService)
        {
        }
        
        public List<News> GetByAuthorId(int userId)
        {
            return _context.News.Where(n => n.UserId == userId).ToList();
        }


    }
}
