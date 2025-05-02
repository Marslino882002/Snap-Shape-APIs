using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Repository.Data.Configurations
{
    public class ConfigureWeightCalorieRecordExtend : IEntityTypeConfiguration<WeightCalorieRecord>
    {
        public void Configure(EntityTypeBuilder<WeightCalorieRecord> builder)
        {


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.CaloriesIntake).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");





        }
    }
}
