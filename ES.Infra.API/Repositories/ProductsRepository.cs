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

        public async Task<ProductsModel> GetById(int id)
        {
            var product = await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<ProductsModel> GetByProduct(string name, string skucode, bool isValid)
        {
            return await _DbsetPessoa.Where(x  => x.Name == name).Where(x => x.SKUCode == skucode).Where(x => x.IsActive == isValid)
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ProductsModel> UpdateStatysAsync(string name, bool isActive)
        {
            // Procura pelo produto com base no nome fornecido
            var product = await DbSet.FirstOrDefaultAsync(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            product.IsActive = isActive;


            return product; // Retorno indicando sucesso na atualização
        }

    }
}
