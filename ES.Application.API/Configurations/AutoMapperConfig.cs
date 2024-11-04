using AutoMapper;
using ES.Services.API.AutoMapper;

namespace ES.Application.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile<AutoMapperProfile>();
            }).CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
