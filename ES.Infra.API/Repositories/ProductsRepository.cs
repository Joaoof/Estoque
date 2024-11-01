using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Repositories
{
    public class ProductsRepository : Repository<ProductsModel>, IProductsRepository
    {

        private readonly DbSet<ProductsModel> _DbsetPessoa;

        public ProductsRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetPessoa = dbFactory.DbContext.Set<ProductsModel>();
        }

        public async Task<ProductsModel> GetByName(string name)
        {
            return await _DbsetPessoa.Where(x  => x.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
