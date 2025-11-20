using System.ComponentModel.DataAnnotations;

namespace Shared.UserDto
{
    public record UserRegistrationDto
    {
        public string? UserName { get; init; }
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 character!")]
        public string? Password { get; init; }
        [Required, EmailAddress(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }
    }
    public enum RegisterUserStatus
    {
        SUCCESS,
        USEREXIST,
        ROLEERROR,
        FAILED
    }
}