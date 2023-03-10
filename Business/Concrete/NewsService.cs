using Business.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        
        public IDataResult<News> GetById(int id)
        {
            var news = _newsRepository.Get(n => n.Id == id);
            if (news != null)
                return new SuccessDataResult<News>(true, "", news);
            else
                return new ErrorDataResult<News>(false, "", news);
        }

        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(true, "", _newsRepository.GetAll());
        }

        public IDataResult<List<News>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<News>>(true, "", _newsRepository.GetAll(p => p.CategoryId == categoryId));
        }

        public IResult Add(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist == null)
            {
                _newsRepository.Add(news);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IResult Update(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                _newsRepository.Update(news);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IResult Delete(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                _newsRepository.Delete(news);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }

        public IResult ChangeStatus(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                if (news.IsActive == true)
                    news.IsActive = false;
                else news.IsActive = true;
                
                _newsRepository.Update(news);
                return new SuccessResult(true, "");
            }
            else
                return new ErrorResult(false, "");
        }
    }
}
