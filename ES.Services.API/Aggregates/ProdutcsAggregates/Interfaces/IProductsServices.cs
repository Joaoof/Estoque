using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces
{
    public interface IProductsServices
    {
        Task<ProductsModel> GetInformationProducts(int id); 
    }
}
