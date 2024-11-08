using ES.Domain.API.Interfaces;
using ES.Domain.API.Interfaces.Repositories;
using ES.Infra.API;
using ES.Infra.API.Context;
using ES.Infra.API.Repositories;
using ES.Services.API.Aggregates.AccountAggregates.Interface;
using ES.Services.API.Aggregates.AccountAggregates.Services;
using ES.Services.API.Aggregates.CategoriesAggregates.Interfaces;
using ES.Services.API.Aggregates.CategoriesAggregates.Services;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using ES.Services.API.Aggregates.ProdutcsAggregates.Services;
using ES.Services.API.Helpers;
using ES.Services.API.Helpers.Interfaces;
using ES.Services.API.Validation.Products;
using FluentValidation.AspNetCore;
using IFA.Domain.API.Interfaces;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Application.API.Configurations
{
    public static class DependecyInjectConfig
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductsModelValidator>());


            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EstoqueContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ES.Application.API"));
            });

            services.AddScoped<Func<EstoqueContext>>((provider) => () => provider.GetService<EstoqueContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IProductsRepository), typeof(ProductsRepository))
                .AddScoped(typeof(ICategoriesRepository), typeof(CategoriesRepository))
                .AddScoped(typeof(IAccountRepository), typeof(AccountRepository))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }

        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager _configuration)
        {
            return services.AddScoped<IProductsAppService, ProductsAppService>()
                .AddScoped<ICategoriesAppService, CategoriesAppService>()
                .AddScoped<IAccountAppService, AccountAppService>()
                .AddScoped<ISkuGenerator, SkuGenerator>();
        }

        public static IServiceCollection AddCors(this IServiceCollection services, ConfigurationManager _configuration)
        {
            var allowedOrigins = _configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            return services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.WithOrigins(allowedOrigins).AllowAnyOrigin().AllowAnyMethod();
                });
            });
        }
    }
}
