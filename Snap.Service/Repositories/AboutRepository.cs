using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Snap.Core.Entities;
using Snap.Core.Entities.Enums;
using Snap.Core.Repositories;
using Snap.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class AboutRepository(SnapDbContext dbContext, UserManager<User> userManager) : IAboutRepository
    {
        public async Task<About> CreateAsync(About about)
        {
            dbContext.Abouts.Add(about);
            await dbContext.SaveChangesAsync();
            return about;
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await dbContext.Abouts.ToListAsync();
        }

        public async Task<About> GetByUserIdAsync(string userId)
        {
            var about = await dbContext.Abouts
                  .FirstOrDefaultAsync(a => a.UserId == userId);

            if (about == null) {return null; }
                

            return about;





        }

        public async Task<Dictionary<string, IEnumerable<string>>> GetEnumChoicesAsync()
        {

            var choices = new Dictionary<string, IEnumerable<string>>
    {
        { "ChronicDiseases", Enum.GetNames(typeof(ChronicDisease)) },
        { "FitnessGoals", Enum.GetNames(typeof(FitnessGoal)) },
        { "MealFrequencies", Enum.GetNames(typeof(MealFrequency)) },
        { "PreferrelFoodTypes", Enum.GetNames(typeof(PreferrelFoodType)) }
    };

            return await Task.FromResult(choices); // Still valid, but 'await' is unnecessary



        }

        public async Task SaveChangesAsync()
        {

          await  dbContext.Abouts.SingleAsync();

        }
    }
}
