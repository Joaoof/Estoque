using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Repositories
{
    public class CategoriesRepository : Repository<CategoriesModel>, ICategoriesRepository
    {
        private readonly DbSet<CategoriesModel> _DbsetPessoa;


        public CategoriesRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetPessoa = dbFactory.DbContext.Set<CategoriesModel>();
        }

        public async Task<List<CategoriesModel>> GetAllCategoriesAsync()
        {
            return await _DbsetPessoa.ToListAsync();
        }
    }
}
