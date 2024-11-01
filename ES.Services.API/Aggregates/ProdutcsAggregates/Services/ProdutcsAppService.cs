using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using System.Linq.Expressions;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Services
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsAppService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductsModel> GetInformationProducts(string name)
        {
            var products = await _productsRepository.GetByName(name);

            return products;
        }

        public async Task<List<ProductsModel>> GetInformationAllProducts()
        {
            var productsAll = await _productsRepository.GetAllAsync();

            return productsAll;
        }

        public async Task<ProductsModel> RegisterProducts(ProductsModel productsModel)
        {
            var register = await _productsRepository.AddAsync(productsModel);
        }
    }
}
