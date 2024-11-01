using ES.Domain.API.Models;
using System.Linq.Expressions;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsAppService
    {
        Task<ProductsModel> GetInformationProduct(string name);

        Task<List<ProductsModel>> GetInformationAllProducts();

        Task<ProductsModel> RegisterProduct(ProductsModel productsModel);

        Task<bool> UpdateProduct(ProductsModel productsModel);

        Task<ProductsModel> DeleteProduct(int id);
    }
}
