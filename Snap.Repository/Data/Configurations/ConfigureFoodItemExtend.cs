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
    public class ConfigureFoodItemExtend : IEntityTypeConfiguration<FoodItem>
    {
        public void Configure(EntityTypeBuilder<FoodItem> builder)
        {


            builder.HasKey("Id"); // Shadow primary key

            builder.Property(f => f.Type)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.Position)
                   .HasMaxLength(50);

            builder.Property(f => f.Freshness)
                   .HasMaxLength(50);

            builder.Property(f => f.WeightGrams)
                   .HasColumnType("decimal(6,2)");

            builder.Property(f => f.Calories)
                   .HasColumnType("decimal(6,2)");




        }
    }
}
