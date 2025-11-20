using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UserDto
{
    public class RefreshTokenDto
    {
        [Required]
        public string? AccessToken { get; set; }
        [Required]

        public string? RefreshToken { get; set; }
    }
}
