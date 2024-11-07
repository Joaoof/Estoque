using System.Linq.Expressions;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);

        Task<T> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<T> Delete(Expression<Func<T, bool>> expression);
    }
}
