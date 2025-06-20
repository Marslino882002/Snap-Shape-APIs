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
    public class ConfigureFoodResultV2Extend : IEntityTypeConfiguration<FoodDetectionResultV2>
    {
        public void Configure(EntityTypeBuilder<FoodDetectionResultV2> builder)
        {
            builder.HasKey(f => f.Id);

           

            builder.HasMany(f => f.Items)
                   .WithOne()
                   .HasForeignKey("FoodDetectionResultV2Id") // Shadow property
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
