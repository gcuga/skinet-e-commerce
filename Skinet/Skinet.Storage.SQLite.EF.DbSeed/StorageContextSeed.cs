using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

using Skinet.Storage.SQLite.EF.Context;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.DbSeed
{
    public class StorageContextSeed
    {
        public static async Task SeedAsync(StorageContext context, ILoggerFactory loggerFactory)
        {
            try
            {
#pragma warning disable EF1001 // Internal EF Core API usage.
                if (!context.ProductTypes.Any())
#pragma warning restore EF1001 // Internal EF Core API usage.
                {
                    var typesData = Encoding.UTF8.GetString(Properties.SeedResources.types);
                    var types = JsonSerializer.Deserialize<List<ProductTypeDto>>(typesData);
                    context.ProductTypes.AddRange(types);
                    await context.SaveChangesAsync();
                }


#pragma warning disable EF1001 // Internal EF Core API usage.
                if (!context.ProductBrands.Any())
#pragma warning restore EF1001 // Internal EF Core API usage.
                {
                    var brandsData = Encoding.UTF8.GetString(Properties.SeedResources.brands);
                    var brands = JsonSerializer.Deserialize<List<ProductBrandDto>>(brandsData);
                    context.ProductBrands.AddRange(brands);
                    await context.SaveChangesAsync();
                }

#pragma warning disable EF1001 // Internal EF Core API usage.
                if (!context.Products.Any())
#pragma warning restore EF1001 // Internal EF Core API usage.
                {
                    var productsData = Encoding.UTF8.GetString(Properties.SeedResources.products);
                    var products = JsonSerializer.Deserialize<List<ProductDto>>(productsData);
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StorageContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
