    using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Request;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Response;
using ES.Services.API.Common;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsAppService
    {
        Task<List<ProductsModel>> GetInformationAllProducts();
        Task<ProductsModel> GetInformationProduct(string name, string skucode, bool isValid);

        Task<ProductsModel> GetInformationProductId(int id);

        Task<ServiceResponse<ProductsViewModelResponse>> RegisterProduct(ProductsViewModel productsViewModels);

        Task<bool> UpdateProduct(ProductsModel productsModel);
        Task<ProductsModel> UpdateProductStatus(string name, bool isActive);

        Task<ProductsModel> DeleteProduct(int id);
    }
}
