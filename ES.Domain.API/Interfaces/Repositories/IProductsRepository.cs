﻿using ES.Domain.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.API.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository<ProductsModel>
    {
        Task<ProductsModel> GetByName (string name);

        Task<ProductsModel> UpdateStatysAsync(string name, bool isActive);
    }
}
