using Microsoft.EntityFrameworkCore;
using ES.Domain.API.Models;

namespace ES.Infra.API.Context
{
    public class EstoqueContext : DbContext
    {
        public DbSet<ProductsModel> Products { get; set; }
    }
}
