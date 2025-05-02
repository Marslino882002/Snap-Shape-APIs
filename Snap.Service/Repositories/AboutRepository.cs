using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Snap.Core.Entities;
using Snap.Core.Entities.Enums;
using Snap.Core.Repositories;
using Snap.Core.Services;
using Snap.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class AboutRepository(SnapDbContext dbContext, UserManager<User> userManager, ILogger
        <AboutRepository> _logger , ICurrentUserService _currentUser) : IAboutRepository
    {
        public async Task<int> AddAsync(About about)
        {

            dbContext.Abouts.Add(about);
            await dbContext.SaveChangesAsync();
            return about.Id;

        }




        public async Task SaveChangesAsync()
        {

            await dbContext.Abouts.SingleAsync();

        }
    }
}
















/*
 
 
 
  try
            {
                // 1) Get the current user’s ID
                var userId = _currentUser.GetUserId();

                // 2) Ensure that user exists
                var user = await userManager.FindByIdAsync(userId.ToString());
                if (user == null)
                    throw new InvalidOperationException($"User '{userId}' not found.");

                // 3) Attach the userId to your About entity
                term.UserId = userId.ToString();

                // 4) Upsert logic
                var existing = await dbContext.Abouts
                                    .SingleOrDefaultAsync(a => a.UserId == userId.ToString());

                if (existing == null)
                {
                    await dbContext.Abouts.AddAsync(term);
                }
                else
                {
                    existing.Age = term.Age;
                    existing.Tall = term.Tall;
                    existing.CurrentWeight = term.CurrentWeight;
                    existing.GoalWeight = term.GoalWeight;
                    existing.Gender = term.Gender;
                    existing.PreferrelFood = term.PreferrelFood;
                    existing.DailyMeals = term.DailyMeals;
                    existing.ChronicDiseases = term.ChronicDiseases;
                    existing.Goal = term.Goal;
                }

                // 5) Save & return the record’s ID
                await dbContext.SaveChangesAsync();
                return existing?.Id ?? term.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddAsync for About.");
                throw;
            }

 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */