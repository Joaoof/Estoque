using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infra.API.Repositories
{
    public class ProductsRepository : Repository<ProductsModel>, IProductsRepository
    {

        private readonly DbSet<ProductsModel> _DbsetPessoa;

        public ProductsRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetPessoa = dbFactory.DbContext.Set<ProductsModel>();
        }

        public Task<ProductsModel> GetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
