using System;
using System.Collections.Generic;
using System.Text;
using Exam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Domain.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.StockKeepingUnit).IsUnique();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StockKeepingUnit).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Quantity).HasDefaultValue(0);
        }
    }
}
