using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost]
        public async Task<IActionResult> Login(Authentication user)
        {
            await authenticationService.SignInAsync(user.Email, user.Password);
            return Ok();
        }

        public async Task<IActionResult> LogOut()
        {
            await authenticationService.SignOutAsync();
            return Ok();
        }
    }
}