using Microsoft.EntityFrameworkCore;
using WT.Product.Data.Context;

namespace WT.Product.API.Configuration
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ProductContext>().Database.Migrate();
            }
        }
    }
}
