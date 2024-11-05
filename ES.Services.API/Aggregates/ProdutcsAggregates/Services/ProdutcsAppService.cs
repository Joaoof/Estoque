using AutoMapper;
using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Request;
using ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Response;
using IFA.Domain.API.Interfaces;
using ES.Services.API.Common;
using ES.Services.API.Helpers;
using ES.Services.API.Helpers.Interfaces;

namespace ES.Services.API.Aggregates.ProdutcsAggregates.Services
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISkuGenerator _skuGenerator;

        public ProductsAppService(IProductsRepository productsRepository, ICategoriesRepository categoriesRepository, IUnitOfWork unitOfWork, IMapper mapper, ISkuGenerator skuGenerator)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _skuGenerator = skuGenerator;
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


        public async Task<ServiceResponse<ProductsViewModelResponse>> RegisterProduct(ProductsViewModel productsViewModels)
        {
            var response = new ServiceResponse<ProductsViewModelResponse>();
            
            // se a string for vazia ou nulla, gera um SKUCODE, se não for pega a que está sendo add manualmente
            productsViewModels.SKUCode = string.IsNullOrEmpty(productsViewModels.SKUCode) ? await _skuGenerator.GenerateUniqueSkuAsync() : productsViewModels.SKUCode;
            
            var isSkuUnique = await _productsRepository.IsSkuUniqueAsync(productsViewModels.SKUCode);

            if (!isSkuUnique)
            {
                response.Success = false; 
                response.Message = "SKU já existe.";
                return response;
            }

            var searchAllCategories = await _categoriesRepository.GetAllCategoriesAsync();
     
           var registerProduct = _mapper.Map<ProductsModel>(productsViewModels);

            var register = await _productsRepository.AddAsync(registerProduct);
            await _unitOfWork.CommitAsync();

            var registeredProductWithCategory = await _productsRepository.GetById(registerProduct.Id);

            var registerProductResponse = _mapper.Map<ProductsViewModelResponse>(registeredProductWithCategory);

            response.Data = registerProductResponse; 
            response.Success = true; 
            return response;

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
