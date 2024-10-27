using ES.Infra.API.Context;
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

            return services;
        }
    }
}
