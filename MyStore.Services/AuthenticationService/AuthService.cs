using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services.Utils;

namespace MyStore.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserAppService userAppService;
        private readonly SignInManager<User> signInManager;
        private readonly AppSettings appSettings;

        public AuthService(IUserAppService userAppService, SignInManager<User> signInManager, IOptions<AppSettings> appSettings)
        {
            this.userAppService = userAppService;
            this.signInManager = signInManager;
            this.appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> LogInAsync(string email, string password)
        {
            try
            {
                var user = await userAppService.GetByEmailAsync(email);

                if (user == null)
                {
                    throw new AppExceptionHandler("User does not exists");
                }

                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);

                if (!signInResult.Succeeded)
                {
                    throw new AppExceptionHandler("Password or email incorect");
                }

                string jwtToken = GenerateJwtToken(user);

                return new AuthenticateResponse(user.EntityToDto(), jwtToken);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task LogOutAsync()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}