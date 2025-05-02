using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Snap.APIs.Errors;
using Snap.APIs.Extensions;
using Snap.APIs.Middlewares;
using Snap.Core.Entities;
using Snap.Repository.Data;
using Snap.Repository.Seeders;
using MediatR;
using Snap.Core.Email.Commands.SendEmail;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Snap.Core.Abouts;
using Microsoft.Data.SqlClient;

namespace Snap.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //     builder.WebHost.UseUrls("http://*:80");
            builder.WebHost.UseUrls("https://localhost:7155", "http://localhost:5000");

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure DbContext
            builder.Services.AddDbContext<SnapDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Configure Identity Services
            builder.Services.AddIdentityServices();         // handles identity setup
            builder.Services.AddAuthenticationService(builder.Configuration); // handles JWT config
            builder.Services.AddAboutServices();
            

            // ✅ Add MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SendEmailCommand>());
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Snap & Shape API",
                        Version = "v1"
                    });

                    //// 🔐 JWT Bearer Auth Setup
                    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer", // <- this makes Swagger add 'Bearer ' automatically
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Paste your JWT token here. No need to type 'Bearer'."
                    });

                    // Apply JWT globally
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Id = "bearerAuth",
                Type = ReferenceType.SecurityScheme
            }
        },
        Array.Empty<string>()
    }
});
                }















                );
            builder.Services.Configure<ApiBehaviorOptions>(
                options => {
                    options.InvalidModelStateResponseFactory = (actionContext) =>
                    {
                        var errors = actionContext.ModelState
                            .Where(p => p.Value.Errors.Count() > 0)
                            .SelectMany(p => p.Value.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray();
                        var validationErrorResponse = new ApiValidationErrorResponse()
                        { Erorrs = errors };
                        return new BadRequestObjectResult(validationErrorResponse);
                    };
                });

            #region DI
            builder.Services.AddMailServices();
            builder.Services.AddCurrentUserService();   
            builder.Services.AddAutoMapper(typeof(AboutProfile));
            builder.Services.AddScrapedProductServices();
            builder.Services.AddAiModelServices();  
            #endregion






            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
              policy.WithOrigins("http://graduationproject-apis.runasp.net") 
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials(); 
                });
            });



            var app = builder.Build();

            #region Apply Migrations and Seed Data

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = services.GetRequiredService<SnapDbContext>();

                // Apply pending migrations
                await dbContext.Database.MigrateAsync();

                // Seed default users
                var userManager = services.GetRequiredService<UserManager<User>>();
                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogInformation("Seeding default users...");
                await UserSeed.SeedUserAsync(userManager);
                logger.LogInformation("User seeding completed.");
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(e, "An error occurred while applying migrations and seeding users.");
            }

            #endregion
            app.UseMiddleware<ExceptionMiddleware>();


            //  Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            #region Enable Swagger in Production
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snap APIs v1");
                c.RoutePrefix = "swagger"; // this makes Swagger available at /swagger
            });
            #endregion
            // Configure Middleware
            app.UseCors("AllowAll");

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
            
        }
    }
}
/*
 
 app.UseMiddleware<ExceptionMiddleware>();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run(); 
 
 
 
 
 
 
 */

/*// ✅ Apply Middleware
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();

            // ✅ Apply CORS Before Other Middleware
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();









{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=db14361.public.databaseasp.net; Database=db14361; User Id=db14361; Password=j@8C!3DfP-c7; Encrypt=False;"
  },
  "JWT": {
    "key": "ThisIsAStrongSecretKeyForJWT123!",
    "ValidIssuer": "https://localhost:7155",
    "ValidAudience": "MySecureKey",
    "DurationInDays": "2"

  }
 
}

*/