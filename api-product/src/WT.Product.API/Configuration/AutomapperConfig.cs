using AutoMapper;
using WT.Product.Domain.Models.Profiles;

namespace WT.Product.API.Configuration
{
    public static class AutomapperConfig
    {
        public static IServiceCollection MapperConfig(this IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<CategoryProfile>();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            return services;
        }
    }
}
