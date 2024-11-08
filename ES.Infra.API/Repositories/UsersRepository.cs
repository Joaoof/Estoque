using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Repositories
{
    public class UsersRepository : Repository<UsersModel>, IUsersRepository
    {
        private readonly DbSet<UsersModel> _DbsetPessoa;

        public UsersRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetPessoa = dbFactory.DbContext.Set<UsersModel>();
        }

        public async Task<UsersModel> GetByIdAsync(int id)
        {
            var user = await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return user;
        }
    }
}
