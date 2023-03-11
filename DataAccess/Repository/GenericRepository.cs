using Core.Services.Logs.Interfaces;
using Core.Services.Results;
using Core.Services.Results.Interfaces;
using DataAccess.Interfaces;
using Entities.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public abstract class GenericRepository<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        protected readonly TContext _context;
        private readonly ILoggerService _logger;

        protected GenericRepository(TContext context, ILoggerService logger)
        {
            _logger = logger;
            _context = context;
        }

        public IResult Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} added to database.");
                return new SuccessResult(true, LogMessage<TEntity>.Add);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while adding {typeof(TEntity).Name} to database: {ex.Message}");
                return new ErrorResult(false, LogMessage<TEntity>.AddError);

            }
        }

        public IResult Delete(TEntity entity)
        {
            try
            {
                var existingEntity = _context.Set<TEntity>().Find(entity.Id);
                _context.Set<TEntity>().Remove(existingEntity);
                _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} deleted from database.");
                return new SuccessResult(true, LogMessage<TEntity>.Delete);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while deleting {typeof(TEntity).Name} from database: {ex.Message}");
                return new ErrorResult(false, LogMessage<TEntity>.DeleteError);

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while getting {typeof(TEntity).Name} from database: {ex.Message}");
                return null;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while getting {typeof(TEntity).Name} list from database: {ex.Message}");
                return null;
            }
        }

        public IResult Update(TEntity entity)
        {
            try
            {
                var existingEntity = _context.Set<TEntity>().Find(entity.Id);
                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} updated in database.");
                return new SuccessResult(true, LogMessage<TEntity>.Update);
                }
                return new ErrorResult(false, LogMessage<TEntity>.UpdateError);

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while updating {typeof(TEntity).Name} in database: {ex.Message}");
                return new ErrorResult(false, LogMessage<TEntity>.UpdateError);

            }
        }
    }
}
