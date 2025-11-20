using Microsoft.AspNetCore.Identity;
using Shared.ResponseApi;
using Shared.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<RegisterUserStatus> RegisterAsync(UserRegistrationDto userForRegistration);
        Task<(LoginStatus status, LoginRespone Token)> LoginAsync(UserLoginDto userLoginDto);
        Task<string> GenerateEmailConfirmationTokeAsync(string email);
        Task<bool> ComfirmEmailAsync(string token, string email);
        Task<(string token, DateTime ValidTo)> GenerateJWTToken(string Email);
        Task<(bool status, LoginRespone Token)> RefreshTokenAsnyc(RefreshTokenDto refreshTokenDto);
        Task<bool> DeleteFreshTokenAsync(string Email);
    }
}
