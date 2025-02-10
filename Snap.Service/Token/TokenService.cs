using Snap.Core.Entities;
using Snap.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Token
{
    public class TokenService : ITokenService
    {
        public Task<string> CreateTokenAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
