using Core.Services.Results.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICategoryService
    {
        IDataResult<Category> Get(int categoryId);
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);

    }
}
