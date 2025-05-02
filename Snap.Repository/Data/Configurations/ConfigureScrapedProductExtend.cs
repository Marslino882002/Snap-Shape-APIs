using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Repository.Data.Configurations
{
    public class ConfigureScrapedProductExtend : IEntityTypeConfiguration<ScrapedProduct>
    {
        public void Configure(EntityTypeBuilder<ScrapedProduct> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Url)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(8,2)");

            builder.Property(p => p.Category)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.ScrapedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
