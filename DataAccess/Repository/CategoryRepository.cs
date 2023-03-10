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
    public class CategoryRepository : GenericRepository<Category, NewsDbContext>, ICategoryRepository
    {
        public CategoryRepository(NewsDbContext context, ILoggerService loggerService) : base(context, loggerService)
        {
        }
    }
    
}
