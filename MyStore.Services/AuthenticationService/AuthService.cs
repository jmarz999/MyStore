using Microsoft.AspNetCore.Identity;
using MyStore.Helpers;
using MyStore.Models;
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

                await signInManager.PasswordSignInAsync(user, password, false, false);

                return string.Empty;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
