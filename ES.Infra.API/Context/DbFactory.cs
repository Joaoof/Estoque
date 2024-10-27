using ES.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace IFA.Infra.API.Context
{
    public class DbFactory : IDisposable
    {

        private bool _disposed;
        private Func<EstoqueContext> _instanceFunc;
        private DbContext _dbContext;

        public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        public DbFactory(Func<EstoqueContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }
        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}