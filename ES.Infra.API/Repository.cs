using ES.Domain.API.Interfaces.Repositories;
using IFA.Infra.API.Context;
using System.Linq.Expressions;

namespace ES.Infra.API
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbFactory dbFactory;

        public Repository(DbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
