﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(6,2)");
            builder.Property(p => p.Description).IsRequired(false).HasColumnType("text");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.SKU).IsRequired().HasMaxLength(10);
        }
    }
}
