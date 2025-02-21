using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.DTOs
{
    public class RegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DispalyName { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,20}$",
            ErrorMessage = "Password must be 6-20 characters long," +
            " include at least one uppercase letter, one number, and one special character.")]
        public string password { get; set; }

    }
}
