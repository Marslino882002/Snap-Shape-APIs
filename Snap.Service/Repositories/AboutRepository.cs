using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Snap.Core.Entities;
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
        public async Task<bool> CreateOrUpdateAbout(About about)
        {



            var user = await userManager.FindByIdAsync(about.UserId);
            if (user == null) return false;

            var Newabout = await dbContext.Abouts.FirstOrDefaultAsync(a => a.UserId == about.UserId);

            if (about == null) 
            {
                Newabout = new About
            {
                UserId = about.UserId,
                Gender = about.Gender,
                Age = about.Age,
                Tall = about.Tall,
                CurrentWeight = about.CurrentWeight,
                GoalWeight = about.GoalWeight,
                PreferrelFood = about.PreferrelFood,
                DailyMeals = about.DailyMeals,
                ChronicDiseases = about.ChronicDiseases,
                Goal = about.Goal
            };
            
            
                        dbContext.Abouts.Add(about);

            
            
            
            
            
            }










            else
            {
                about.Gender = about.Gender;
                about.Age = about.Age;
                about.Tall = about.Tall;
                about.CurrentWeight = about.CurrentWeight;
                about.GoalWeight = about.GoalWeight;
                about.PreferrelFood = about.PreferrelFood;
                about.DailyMeals = about.DailyMeals;
                about.ChronicDiseases = about.ChronicDiseases;
                about.Goal = about.Goal;
                dbContext.Abouts.Update(about);
            }
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<About> GetAboutByUserId(string userId)
        {
            return await dbContext.Abouts.FirstOrDefaultAsync(a => a.UserId == userId);
        }
    }
}
