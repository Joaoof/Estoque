]using ES.Domain.API.Models;
]using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Services
{
    public class ProdutcsAppService : IProductsServices
    {
        private readonly IProductsRepository _productsRepository;
        public Task<ProductsModel> GetInformationProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
