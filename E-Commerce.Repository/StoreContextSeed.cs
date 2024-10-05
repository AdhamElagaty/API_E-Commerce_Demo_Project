using E_Commerce.Data.Contexts;
using E_Commerce.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(ECommerceDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../E-Commerce.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if (brands is not null)
                        await context.ProductBrands.AddRangeAsync(brands);
                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../E-Commerce.Repository/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types is not null)
                        await context.ProductTypes.AddRangeAsync(types);
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../E-Commerce.Repository/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products is not null)
                        await context.Products.AddRangeAsync(products);
                }
                if (context.DeliveryMethods != null && !context.DeliveryMethods.Any())
                {
                    var methodsData = File.ReadAllText("../E-Commerce.Repository/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(methodsData);
                    if (methods is not null)
                        await context.DeliveryMethods.AddRangeAsync(methods);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
