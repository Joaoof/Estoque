using ES.Domain.API.Models;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface ICategoriesRepository : IRepository<CategoriesModel>
    {
        Task<List<CategoriesModel>> GetAllCategoriesAsync();
    }
}
