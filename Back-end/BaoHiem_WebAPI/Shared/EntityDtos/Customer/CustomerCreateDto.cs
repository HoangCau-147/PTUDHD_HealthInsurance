using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityDtos.Customer
{
    public class CustomerCreateDto
    {
        [Required, EmailAddress(ErrorMessage = "Username is a Email!")]
        public string? UserName { get; init; }
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 character!")]
        public string? Password { get; init; }
        [Required, EmailAddress(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        public ICollection<string>? Roles { get; init; }
        public string? Name { get; init; }
        public string? IdentifycationNumber { get; init; }
        public DateTime? Birthday { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Address { get; init; }
    }
}
