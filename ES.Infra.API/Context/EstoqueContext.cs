using Microsoft.EntityFrameworkCore;
using ES.Domain.API.Models;

namespace ES.Infra.API.Context
{
    public class EstoqueContext : DbContext
    {
        public DbSet<ProductsModel> Products { get; set; }

        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public"); // Especifica o schema padrão como "public"
            base.OnModelCreating(modelBuilder);
        }

    }
}
