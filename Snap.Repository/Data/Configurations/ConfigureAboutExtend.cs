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
    public class ConfigureAboutExtend : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {

            builder.HasKey(a => a.Id);

            // Configure properties
            //builder.Property(a => a.Gender)
            //       .IsRequired()
            //       .HasMaxLength(50);
            builder.Property(a => a.Gender)
                   .HasConversion<string>()
                   .HasMaxLength(50);


            builder.Property(a => a.Age)
                   .IsRequired();

            builder.Property(a => a.Tall)
                   .IsRequired();



            builder.Property(a => a.CurrentWeight)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)"); // Adjust precision and scale as needed

            builder.Property(a => a.GoalWeight)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)"); // Adjust precision and scale as needed

            // Configure enums to be stored as strings
            builder.Property(a => a.PreferrelFood)
                   .HasConversion<string>()
                   .HasMaxLength(50);



            builder.Property(a => a.DailyMeals)
                 .HasConversion<string>()
                 .HasMaxLength(50);

            builder.Property(a => a.ChronicDiseases)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(a => a.Goal)
                   .HasConversion<string>()
                   .HasMaxLength(50);



            // Configure the one-to-one relationship with User
            builder.HasOne(a => a.User)
                   .WithOne(u => u.about)
                   .HasForeignKey<About>(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Cascade delete if User is deleted

        }
    }
}
