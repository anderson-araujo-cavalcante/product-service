using WT.Product.Data.Context;
using WT.Product.Data.Repositories.Concrets;
using WT.Product.Data.Repositories.Interfaces;
using WT.Product.Domain.Services.Concrets;
using WT.Product.Domain.Services.Interfaces;

namespace WT.Product.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProductContext>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
