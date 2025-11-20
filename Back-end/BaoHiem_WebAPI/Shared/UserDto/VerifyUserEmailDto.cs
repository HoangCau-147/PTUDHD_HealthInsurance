using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UserDto
{
    public class VerifyUserEmailDto
    {
        [Required, EmailAddress(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
