using ES.Domain.API.Models;

namespace ES.Services.API.Aggregates.CategoriesAggregates.Interfaces
{
    public interface ICategoriesAppService
    {
        Task<List<CategoriesModel>> GetAllCategoriesAsync();
    }
}
