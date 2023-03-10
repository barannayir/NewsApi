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
        public CategoryRepository(NewsDbContext context) : base(context)
        {
        }
    }
    
}
