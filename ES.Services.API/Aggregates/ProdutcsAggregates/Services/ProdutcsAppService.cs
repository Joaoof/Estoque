using AutoMapper;
using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Request;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Response;
using IFA.Domain.API.Interfaces;
using System.Linq.Expressions;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Services
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsAppService(IProductsRepository productsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductsModel>> GetInformationAllProducts()
        {
            var productsAll = await _productsRepository.GetAllAsync();

            return productsAll;
        }

        public async Task<ProductsModel> GetInformationProduct(string name, string skucode, bool isValid)
        {
            var products = await _productsRepository.GetByProduct(name, skucode, isValid);

            return products;
        }

        public async Task<ProductsModel> GetInformationProductId(int id)
        {
            var products = await _productsRepository.GetById(id);

            return products;
        }


        public async Task<ProductsViewModelResponse> RegisterProduct(ProductsViewModel productsViewModels)
        {
            var registerProduct = _mapper.Map<ProductsModel>(productsViewModels);

            var register = await _productsRepository.AddAsync(registerProduct);
            await _unitOfWork.CommitAsync();

            var registeredProductWithCategory = await _productsRepository.GetById(registerProduct.Id);

            var registerProductResponse = _mapper.Map<ProductsViewModelResponse>(registeredProductWithCategory);


            return registerProductResponse;
        }

        public async Task<bool> UpdateProduct(ProductsModel productsModel)
        {
            var update = await _productsRepository.UpdateAsync(productsModel);

            await _unitOfWork.CommitAsync();

            return update;
        }
        public async Task<ProductsModel> UpdateProductStatus(string name, bool isActive)
        {
            var product = await _productsRepository.GetAllAsync(p => p.Name == name);

            var updateSucess = await _productsRepository.UpdateStatysAsync(product.First().Name, isActive);
            await _unitOfWork.CommitAsync();

            return updateSucess;
            
        }

        public async Task<ProductsModel> DeleteProduct(int id)
        {
            var delete = await _productsRepository.Delete(x => x.Id == id);
            await _unitOfWork.CommitAsync();

            return delete;
        }

    }
}
