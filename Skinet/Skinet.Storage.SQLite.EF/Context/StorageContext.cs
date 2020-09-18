using System.Linq;

using Microsoft.EntityFrameworkCore;

using Skinet.Storage.SQLite.EF.Config;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Context
{
    public class StorageContext : DbContext
    {
        public DbSet<ProductDto> Products { get; set; }

        public DbSet<ProductTypeDto> ProductTypes { get; set; }

        public DbSet<ProductBrandDto> ProductBrands { get; set; }

        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType
                        .ClrType
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
}
