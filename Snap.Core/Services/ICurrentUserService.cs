using Microsoft.Extensions.Logging;
using Snap.Core.Constants;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Services
{
    public interface ICurrentUserService
    {

        string GetUserId();

        Task<User> GetUserAsync();
        Task<List<string>> GetCurrentUserRolesAsync();
        Task EnsureAuthorizedUser(List<UserRoles> requiredRoles, ILogger logger);
    }
}
