using Business.Interfaces;
using Core.Services.Logs.Interfaces;
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
        private readonly ILoggerService _loggerService;

        public NewsService(INewsRepository newsRepository, ILoggerService loggerService)
        {
            _newsRepository = newsRepository;
            _loggerService = loggerService;
        }

        public IDataResult<News> GetById(int id)
        {
            var news = _newsRepository.Get(n => n.Id == id);
            if (news != null)
                return new SuccessDataResult<News>(true, LogMessage<News>.Get, news);
            else
                return new ErrorDataResult<News>(false, LogMessage<News>.GetError, null);
        }

        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(true, LogMessage<News>.GetAll, _newsRepository.GetAll());
        }

        public IDataResult<List<News>> GetAllActiveNews()
        {
            var activeNews = _newsRepository.GetActiveNews();
            return new SuccessDataResult<List<News>>(true, LogMessage<News>.GetAll, activeNews);
        }

        public IDataResult<List<News>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<News>>(true, LogMessage<News>.GetAll, _newsRepository.GetAll(x => x.CategoryId == categoryId));
        }

        public IResult Add(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist == null)
            {
                _newsRepository.Add(news);
                return new SuccessResult(true, LogMessage<News>.Add);
            }
            else
                return new ErrorResult(false, LogMessage<News>.AddError);
        }

        public IResult Update(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                _newsRepository.Update(news);
                return new SuccessResult(true, LogMessage<News>.Update);
            }
            else
                return new ErrorResult(false, LogMessage<News>.UpdateError);
        }

        public IResult Delete(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                var result = _newsRepository.Delete(news);
                return new SuccessResult(true, LogMessage<News>.Delete);
            }
            else
                return new ErrorResult(false, LogMessage<News>.DeleteError);
        }

        public IResult DeleteById(int id)
        {
            var isExsist = _newsRepository.Get(n => n.Id == id);
            if (isExsist != null)
            {
                _newsRepository.Delete(isExsist);
                return new SuccessResult(true, LogMessage<News>.Delete);
            }
            else
                return new ErrorResult(false, LogMessage<News>.DeleteError);
        }

        public IResult ChangeStatus(News news)
        {
            var isExsist = _newsRepository.Get(n => n.Id == news.Id);
            if (isExsist != null)
            {
                _newsRepository.Update(news);
                return new SuccessResult(true, LogMessage<News>.Update);
            }
            else
                return new ErrorResult(false, LogMessage<News>.UpdateError);
        }
    }
}
