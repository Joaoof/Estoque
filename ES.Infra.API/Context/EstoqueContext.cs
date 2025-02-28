﻿using ES.Domain.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ES.Infra.API.Context
{
    public class EstoqueContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ProductsModel> Products { get; set; }

        public DbSet<CategoriesModel> Categories { get; set; }

        public DbSet<UsersModel> Users { get; set; }

        //public DbSet<RegisterModel> Register { get; set; }

        public DbSet<LoginModel> Login { get; set; }

        public DbSet<SuppliersModel> Suppliers { get; set; }

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


            //modelBuilder.Entity<UsersModel>().HasOne(user => user.UserRole).
            //    WithMany(role => role.Users)
            //    .HasForeignKey(user => user.UserRoleId);


            // Se n tiver cria por padrão isso aqui
            modelBuilder.Entity<UsersModel>().HasData(new UsersModel
            {
                Id = 1,
                Name = "admin",
                Email = "admin@teste.com.br",
                Password = "admin",
            });

            //modelBuilder.Entity<RegisterModel>().HasNoKey();
            modelBuilder.Entity<LoginModel>().HasNoKey();


        }

    }
}
