using Core.Services.Results.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INewsService
    {
        IDataResult<News> GetById(int id);
        IDataResult<List<News>> GetAll();
        IDataResult<List<News>> GetByCategory(int categoryId);
        IResult Add(News news);
        IResult Update(News news);
        IResult Delete(News news);
        IResult DeleteById(int id);
        IResult ChangeStatus(News news);
    }
}
    
