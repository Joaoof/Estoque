﻿using ES.Domain.API.Interfaces.Repositories;
using ES.Domain.API.Models;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Repositories
{
    public class CategoriesRepository : Repository<CategoriesModel>, ICategoriesRepository
    {
        private readonly DbSet<CategoriesModel> _DbsetCategory;


        public CategoriesRepository(DbFactory dbFactory) : base(dbFactory)
        {
            _DbsetCategory = dbFactory.DbContext.Set<CategoriesModel>();
        }

        public async Task<List<CategoriesModel>> GetAllCategoriesAsync()
        {
            return await _DbsetCategory.ToListAsync();
        }
    }
}
