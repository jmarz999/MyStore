using Microsoft.AspNetCore.Identity;
using MyStore.Helpers;
using MyStore.Models;
using System;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserAppService userAppService;
        private readonly SignInManager<User> signInManager;

        public AuthService(IUserAppService userAppService, SignInManager<User> signInManager)
        {
            this.userAppService = userAppService;
            this.signInManager = signInManager;
        }

        public async Task<string> LogInAsync(string email, string password)
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

                //here we generate a jwt and retreieve it
                return string.Empty;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
