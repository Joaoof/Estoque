using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsAppService
    {
        Task<ProductsModel> GetInformationProducts(int id); 
    }
}
