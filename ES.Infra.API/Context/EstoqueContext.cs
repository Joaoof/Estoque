using Microsoft.EntityFrameworkCore;
using ES.Domain.API.Models;

namespace ES.Infra.API.Context
{
    public class EstoqueContext : DbContext
    {
        public DbSet<ProductsModel> Products { get; set; }

        public DbSet<CategoriesModel> Categories { get; set; }

        public DbSet<UsersModel> Users { get; set; }

        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("public"); // Especifica o schema padrão como "public"
        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriesModel>().HasMany(category => category.Products)
                .WithOne(Products => Products.Categories).HasForeignKey(product => product.CategoryId);


            modelBuilder.Entity<UsersModel>().HasOne(user => user.UserRole).
                WithMany(role => role.Users)
                .HasForeignKey(user => user.UserRoleId);

            // Se n tiver cria por padrão isso aqui
            modelBuilder.Entity<UsersModel>().HasData(new UsersModel
            {
                Name = "admin",
                Email = "admin@teste.com.br",
                Password = "admin",
                UserRole = new UserRolesModel
                {
                    RoleName = Domain.API.Enuns.RolesEnum.Admin,
                }
            });
        }

    }
}
