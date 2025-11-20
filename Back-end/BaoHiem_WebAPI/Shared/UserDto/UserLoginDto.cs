using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UserDto
{
    public class UserLoginDto
    {
        [Required, EmailAddress(ErrorMessage = "Username is required!")]
        public string? Email { get; set; }
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters!")]
        public string? Password { get; set; }
    }
    public enum LoginStatus
    {
        USERNOTEXIST,
        INCORRECTPASSWORD,
        EMAILNOTCONFIRMED,
        SUCCESS
    }
}
