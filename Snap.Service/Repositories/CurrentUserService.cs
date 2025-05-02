using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Snap.Core.Constants;
using Snap.Core.Entities;
using Snap.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class CurrentUserService: ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }




        public string GetUserId()
        {
            var claim = _httpContextAccessor
                            .HttpContext?
                            .User?
                            .FindFirst(ClaimTypes.NameIdentifier)?
                            .Value;

            if (string.IsNullOrWhiteSpace(claim))
                throw new UnauthorizedAccessException("User ID claim is missing.");

            return claim;   // return the raw string (GUID), do NOT parse to int
        }

        public async Task<User> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UnauthorizedAccessException("User not found.");
            return user;
        }

        public Task<List<string>> GetCurrentUserRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task EnsureAuthorizedUser(List<UserRoles> requiredRoles, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}



/*#region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        #endregion
        #region Constructors
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
                    }
        #endregion
        #region Functions
        public int GetUserId()
        {
            // Get the User ID claim from the JWT token
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Check if the claim is missing
            if (userIdClaim == null)
            {
                // Log detailed info for debugging purposes
                throw new UnauthorizedAccessException("User ID claim is missing from the token.");
            }

            // Try parsing the User ID claim to an integer
            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }

            // Log the error if the claim cannot be parsed to an integer
            throw new UnauthorizedAccessException("User ID is invalid or cannot be parsed.");

        }

        public async Task<User> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            { throw new UnauthorizedAccessException(); }
            return user;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public async Task EnsureAuthorizedUser(List<UserRoles> requiredRoles, ILogger logger)
        {
            var user = await GetUserAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            var matched = userRoles
                .Select(r => Enum.TryParse<UserRoles>(r, out var parsed) ? parsed : (UserRoles?)null)
                .Where(r => r != null)
                .Select(r => r!.Value)
                .Intersect(requiredRoles)
                .Any();

            if (!matched)
            {
                logger.LogWarning("Unauthorized access attempt by user: {UserId}", user.Id);
                throw new UnauthorizedAccessException("Permission denied.");
            }

            logger.LogInformation("User {UserId} authorized with roles: {Roles}", user.Id, string.Join(",", userRoles));
        }

       
        #endregion*/