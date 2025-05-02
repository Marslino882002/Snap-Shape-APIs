using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Snap.APIs.Extensions
{
    public static class AddAuthenticationExtension
    {

        public static IServiceCollection AddAuthenticationService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(Options =>
            { 
            
            Options.TokenValidationParameters= new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:ValidIssuer"],
                ValidAudience =configuration["JWT:ValidAudience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:key"])),
                
            };  





            }
            
            
            
            );
            
                

            return services;
        }






    }
}
