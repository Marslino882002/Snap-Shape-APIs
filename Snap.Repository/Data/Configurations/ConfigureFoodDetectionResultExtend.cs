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
    public class ConfigureFoodDetectionResultExtend : IEntityTypeConfiguration<FoodDetectionResult>
    {
        public void Configure(EntityTypeBuilder<FoodDetectionResult> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DetectedObjects)
                   .HasConversion(
                       v => string.Join(';', v),         // Convert list to string for DB
                       v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                   );

            builder.Property(f => f.FreshnessStatus)
                   .HasConversion(
                       v => string.Join(';', v),
                       v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                   );

            builder.ToTable("FoodDetectionResults");
        }
    }
}
