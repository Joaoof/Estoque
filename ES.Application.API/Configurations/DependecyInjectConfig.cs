using ES.Domain.API.Interfaces.Repositories;
using ES.Infra.API;
using ES.Infra.API.Context;
using ES.Infra.API.Repositories;
using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using ES.Services.API.Aggregates.ProdutcsAggregates.Services;
using IFA.Domain.API.Interfaces;
using IFA.Infra.API;
using IFA.Infra.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.Application.API.Configurations
{
    public static class DependecyInjectConfig
    {
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
                .AddScoped(typeof(IProductsRepository), typeof(ProductsRepository)).AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }

        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager _configuration)
        {
            return services.AddScoped<IProductsAppService, ProductsAppService>();
        }
    }
}
