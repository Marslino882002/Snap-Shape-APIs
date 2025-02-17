using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Entities
{
    public class User : IdentityUser
    {
        public string DispalyName { get; set; }
        // Navigation property to About (1:1)
        [EncryptColumn]
        public string? OTP { get; set; }
        public About about { get; set; }
    }
}
