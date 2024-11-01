using ES.Domain.API.Models;
using System.Linq.Expressions;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsAppService
    {
        Task<ProductsModel> GetInformationProducts(string name);

        Task<List<ProductsModel>> GetInformationAllProducts();

        Task<ProductsModel> RegisterProducts(ProductsModel productsModel);

        Task<bool> UpdateProducts(ProductsModel productsModel);
    }
}
