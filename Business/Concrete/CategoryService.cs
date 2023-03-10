using Business.Interfaces;
using Core.Services.Logs.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILoggerService _loggerService;

        public CategoryService(ICategoryRepository categoryRepository, ILoggerService loggerService)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public IResult Add(Category category)
        {
            var isExsist = _categoryRepository.Get(n => n.CategoryName == category.CategoryName);
            if (isExsist == null)
            {
                _categoryRepository.Add(category);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IResult Delete(Category category)
        {
            var isExsist = _categoryRepository.Get(n => n.Id == category.Id);
            if (isExsist != null)
            {
                _categoryRepository.Delete(category);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var category = _categoryRepository.Get(n => n.Id == categoryId);
            if (category != null)
                return new SuccessDataResult<Category>(true, "", category);
            else
                return new ErrorDataResult<Category>(false, "", category);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(true, "", _categoryRepository.GetAll());
        }

        public IResult Update(Category category)
        {
            var isExsist = _categoryRepository.Get(n => n.Id == category.Id);
            if (isExsist != null)
            {
                _categoryRepository.Update(category);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }
    }
}
