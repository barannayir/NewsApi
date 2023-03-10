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
    public class NewsRepository : GenericRepository<News, NewsDbContext>, INewsRepository
    {
        public NewsRepository(NewsDbContext context) : base(context)
        {
        }
        
 
    }
}
