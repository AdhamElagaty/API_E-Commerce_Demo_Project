using E_Commerce.Data.Contexts;
using E_Commerce.Data.Entities.IdentityEntities;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ECommerceDbContext>();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();

                    await context.Database.MigrateAsync();
                    await ECommerceContextSeed.SeedAsync(context, loggerFactory);
                    await ECommerceIdentityContextSeed.SeedUsersAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            }

        }
    }
}
