using ES.Domain.API.Models;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository<ProductsModel>
    {
        Task<ProductsModel> GetByProduct(string name, string skucode, bool isValid);
        Task<ProductsModel> GetById(int id);

        //Task<ProductsModel> AddProductAsync(ProductsViewModel productsViewModel);

        Task<ProductsModel> UpdateStatysAsync(string name, bool isActive);
    }
}
