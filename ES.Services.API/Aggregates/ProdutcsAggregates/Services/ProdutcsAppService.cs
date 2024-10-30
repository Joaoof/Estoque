using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Services
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsAppService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductsModel> GetInformationProducts(int id)
        {
            var products = await _productsRepository.GetId(id);

            return products;
        }
    }
}
