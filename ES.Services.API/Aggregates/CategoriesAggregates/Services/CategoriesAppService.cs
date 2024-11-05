using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using ES.Services.API.Aggregates.CategoriesAggregates.Interfaces;

namespace ES.Services.API.Aggregates.CategoriesAggregates.Services
{
    public class CategoriesAppService : ICategoriesAppService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesAppService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoriesModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();

            return categories;
        }
    }
}
