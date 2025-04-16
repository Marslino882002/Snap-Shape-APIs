using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class AboutRepository(SnapDbContext dbContext, UserManager<User> userManager , ILogger
        <AboutRepository> _logger) : IAboutRepository
    {
        public async Task<int> AddAsync(About term)
        {
            try
            {
                // Make sure the UserId exists in AspNetUsers (if you're using foreign key constraints)
                var user = await dbContext.Users.FindAsync(term.UserId);
                if (user == null)
                {
                    throw new InvalidOperationException("User with the given UserId does not exist.");
                }

                // Add the About entity and save changes
                await dbContext.Abouts.AddAsync(term);
                await dbContext.SaveChangesAsync();

                return term.Id;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // (Ensure you have logging set up in your app)
                _logger.LogError(ex, "An error occurred while adding About entity.");
                throw;















            }
        }

        public async Task SaveChangesAsync()
        {

          await  dbContext.Abouts.SingleAsync();

        }
    }
}
