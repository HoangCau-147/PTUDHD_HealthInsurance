using AutoMapper;
using Contracts;
using Entity.Models;
using Entity.Models.Customers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service.Contracts;
using Shared.EntityDtos.Customer;
using Shared.ResponseApi;
using Shared.UserDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationService(IMapper mapper, IRepositoryManager repository, IConfiguration configuration,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager) {
            this._mapper = mapper;
            this._repository = repository;
            this._configuration = configuration;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<RegisterUserStatus> RegisterAsync(UserRegistrationDto userForRegistration)
        {
            var userRegister = _mapper.Map<User>(userForRegistration);

            //Check user exits
            var userExit = await _userManager.FindByEmailAsync(userRegister.Email);
            if (userExit != null)
            {
                return RegisterUserStatus.USEREXIST;
            }
            var listUserRoles = new List<string>();
            foreach (var role in userForRegistration.Roles)
            {
                var roleExit = await _roleManager.FindByNameAsync(role);
                if (roleExit != null)
                {
                    listUserRoles.Add(roleExit.Name);
                }
            }
            if (listUserRoles.Count > 0)
            {
                // Create user
                var result = await _userManager.CreateAsync(userRegister, userForRegistration.Password);
                if (!result.Succeeded)
                {
                    return RegisterUserStatus.FAILED;
                }

                // Add roles to user
                await _userManager.AddToRolesAsync(userRegister, listUserRoles);

                await _repository.SaveAsync();

                return RegisterUserStatus.SUCCESS;
            }
            else
            {
                return RegisterUserStatus.ROLEERROR;
            }
        }
        public async Task<string> GenerateEmailConfirmationTokeAsync(string Email)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return token;
            }
            return string.Empty;
        }
        public async Task<(LoginStatus status, LoginRespone Token)> LoginAsync(UserLoginDto userLoginDto)
        {
            var resultUsername = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (resultUsername != null)
            {
                var result = await _userManager.CheckPasswordAsync(resultUsername, userLoginDto.Password);
                if (!result)
                {
                    return (LoginStatus.INCORRECTPASSWORD, new LoginRespone());
                }
                var checkConfirmEmail = await _userManager.IsEmailConfirmedAsync(resultUsername);
                if (!checkConfirmEmail) {
                    return (LoginStatus.EMAILNOTCONFIRMED, new LoginRespone());
                }

                var refreshToken = GenerateRefreshToken();
                resultUsername.RefreshToken = refreshToken;
                resultUsername.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                await _userManager.UpdateAsync(resultUsername);

                var accessToken = await GenerateJWTToken(userLoginDto.Email);
                var role = await _userManager.GetRolesAsync(resultUsername);

                var response = new LoginRespone { AccessToken = accessToken.token, RefreshToken = refreshToken, ValidTo = accessToken.ValidTo,
                Role = role.First()};
                return (LoginStatus.SUCCESS, response);
            }
            else
            {
                return (LoginStatus.USERNOTEXIST, new LoginRespone());
            }
        }
        public async Task<(string token, DateTime ValidTo)> GenerateJWTToken(string Email)
        {
            var resultUser = await _userManager.FindByEmailAsync(Email);
            if (resultUser == null)
            {
                return new (string.Empty, DateTime.Now);
            }
            var role = await _userManager.GetRolesAsync(resultUser);
            if(role.Count == 0)
            {
                var customerRole = await _roleManager.GetRoleNameAsync(new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                });
                await _userManager.AddToRoleAsync(resultUser, customerRole);
                role = await _userManager.GetRolesAsync(resultUser);
            }
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, role.First())

                };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken
            (
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new (new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }
        public async Task<bool> ComfirmEmailAsync(string token, string email)
        {
            // Check Email Exist\
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;

        }
        public async Task<(bool status, LoginRespone Token)> RefreshTokenAsnyc(RefreshTokenDto refreshTokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);

            if (principal is null)
                return new (false, new LoginRespone());
            else
            {
                Claim emailClaim = principal.FindFirst(ClaimTypes.Email);

                if (emailClaim != null)
                {
                    string userEmail = emailClaim.Value;
                    var user = await _userManager.FindByEmailAsync(userEmail);

                    if (user is null || refreshTokenDto.RefreshToken != user?.RefreshToken || user?.RefreshTokenExpiry < DateTime.UtcNow)
                    {
                        return new(false, new LoginRespone());
                    }
                    var token = await GenerateJWTToken(userEmail);
                    var loginRespone = new LoginRespone
                    {
                        ValidTo = token.ValidTo,
                        AccessToken = token.token,
                        RefreshToken = user.RefreshToken
                    };
                    return new(true, loginRespone);
                }
                else
                {
                    return new(false, new LoginRespone());
                }
            }
            
        }
        public async Task<bool> DeleteFreshTokenAsync(string Email)
        {
            var logoutUser = await _userManager.FindByEmailAsync(Email);
            if(logoutUser != null)
            {
                logoutUser.RefreshToken = null;
                logoutUser.RefreshTokenExpiry = DateTime.UtcNow;

                await _userManager.UpdateAsync(logoutUser);
                return true;
            }
            return false;
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = authenKey,
                ValidateIssuer = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidateLifetime = false // Set this to true if you want to validate token lifetime
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return principal;
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
