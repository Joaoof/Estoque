using ES.Domain.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<ProductsModel> GetId (int id);
    }
}
