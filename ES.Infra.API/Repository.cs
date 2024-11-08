using ES.Domain.API.Interfaces;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ES.Infra.API
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        protected DbSet<T> DbSet
        {
            get => _dbSet ??= _dbFactory.DbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
            {
                return await DbSet.ToListAsync();
            }
            else
            {
                return await DbSet.Where(filter).ToListAsync();
            }
        }
        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);

            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity != null)
            {
                try
                {
                    var result = DbSet.Update(entity);

                    return result.State == EntityState.Modified;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
        public async Task<T> Delete(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                var itemDelete = await DbSet.FirstOrDefaultAsync(expression);
                if (itemDelete != null)
                {
                    DbSet.Remove(itemDelete);
                }
                return itemDelete;
            }

            return null;

        }
    }
}
