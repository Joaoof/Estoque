using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Repositories
{
    public class SuppliersRepository : Repository<SuppliersModel>, ISuppliersRepository
    {
        private readonly DbSet<SuppliersModel> _DbsetSuppliers;

        public SuppliersRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetSuppliers = dbFactory.DbContext.Set<SuppliersModel>();
        }

    }
}
