﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface INewsRepository : IEntityRepository<News>
    {
        List<News> GetActiveNews();
        List<News> GetByAuthorId(int userId);
    }
}
