using Microsoft.EntityFrameworkCore;
using WT.Product.Data.Context;

namespace WT.Product.API.Configuration
{
    public static class ConnectionConfig
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContextPool<ProductContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
            ));

            return builder;
        }
    }
}
