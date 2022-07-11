using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DotnetEcommerce.Core.Entities;
using Microsoft.Extensions.Logging;

namespace DotnetEcommerce.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactor)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandItems = File.ReadAllText("../Infrastructure/Data/SeedData/Brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandItems);
                    foreach (var item in brands)
                    {
                        await context.ProductBrands.AddAsync(item);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.ProductTypes.Any())
                {
                    var typeItem = File.ReadAllText("../Infrastructure/Data/SeedData/Types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeItem);
                    foreach (var item in types)
                    {
                        await context.ProductTypes.AddAsync(item);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Products.Any())
                {
                    var productItems = File.ReadAllText("../Infrastructure/Data/SeedData/Products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productItems);
                    foreach (var item in products)
                    {
                        await context.Products.AddAsync(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactor.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
