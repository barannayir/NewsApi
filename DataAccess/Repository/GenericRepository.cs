using Core.Services.Logs.Interfaces;
using DataAccess.Interfaces;
using Entities.Abstract;
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

        public void Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} added to database.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while adding {typeof(TEntity).Name} to database: {ex.Message}");
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} deleted from database.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while deleting {typeof(TEntity).Name} from database: {ex.Message}");
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

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation($"{typeof(TEntity).Name} updated in database.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error while updating {typeof(TEntity).Name} in database: {ex.Message}");
            }
        }
    }
}
