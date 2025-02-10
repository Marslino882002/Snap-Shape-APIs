using Microsoft.AspNetCore.Identity;
using Snap.Core.Entities;
using Snap.Repository.Data;
using System.Security.Principal;

namespace Snap.APIs.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection Services) 
        { 
        
        Services.AddIdentity<User , IdentityRole>()
                .AddEntityFrameworkStores<SnapDbContext>();


            Services.AddAuthentication();
        
        
        
        return Services;
        
        
        
        }








    }
}
