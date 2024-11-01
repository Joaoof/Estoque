using ES.Domain.API.Models;
using System.Linq.Expressions;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsAppService
    {
        Task<ProductsModel> GetInformationProduct(string name, string skucode, bool isValid);

        Task<List<ProductsModel>> GetInformationAllProducts();

        Task<ProductsModel> RegisterProduct(ProductsModel productsModel);

        Task<bool> UpdateProduct(ProductsModel productsModel);
        Task<ProductsModel> UpdateProductStatus(string name, bool isActive);

        Task<ProductsModel> DeleteProduct(int id);
    }
}
