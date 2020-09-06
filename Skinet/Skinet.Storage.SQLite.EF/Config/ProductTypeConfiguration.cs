using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeDto>
    {
        public void Configure(EntityTypeBuilder<ProductTypeDto> builder)
        {
            builder.ToTable("ProductType");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).IsRequired();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
