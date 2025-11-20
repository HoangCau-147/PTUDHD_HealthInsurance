using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Staff
{
    public class EmployeeCreateDto
    {
        public string? UserName { get; init; }
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 character!")]
        public string? Password { get; init; }
        [Required, EmailAddress(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        public ICollection<string>? Roles { get; init; }
        public string? Name { get; set; }
        public string? IdentifycationNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
