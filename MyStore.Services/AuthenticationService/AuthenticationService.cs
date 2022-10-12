using Microsoft.AspNetCore.Identity;
using MyStore.Helpers;
using MyStore.Models;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserAppService userAppService;
        private readonly SignInManager<User> signInManager;

        public AuthenticationService(IUserAppService userAppService, SignInManager<User> signInManager)
        {
            this.userAppService = userAppService;
            this.signInManager = signInManager;
        }

        public async Task<string> SignInAsync(string email, string password)
        {
            var user = await userAppService.GetByEmailAsync(email);

            if (user != null)
            {
                await signInManager.PasswordSignInAsync(user, password, false, false);
            }

            throw new AppExceptionHandler("User already exists");
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
