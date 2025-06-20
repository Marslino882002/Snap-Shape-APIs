using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Snap.Core.DTOs;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Repository.Data
{
    public class SnapDbContext: IdentityDbContext<User>
    {

        //private readonly IEncryptionProvider encryption;


        public SnapDbContext()
        {
            
        }
        public SnapDbContext(DbContextOptions<SnapDbContext>options ) : base(options)
        {

         //   encryption = new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");
            


           

        }
// DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ScrapedProduct> ScrapedProducts { get; set; }
        public DbSet<WeightCalorieRecord> WeightCalorieRecords { get; set; }
        public DbSet<FoodDetectionResult> FoodDetectionResults { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
        public DbSet<FoodDetectionResultV2> foodDetectionResultV2s { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           // modelBuilder.UseEncryption(encryption);
        }


 


    }
}
