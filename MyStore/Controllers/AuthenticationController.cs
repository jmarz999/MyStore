using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthService authenticationService;

        public AuthenticationController(IAuthService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(Authentication user)
        {
            await authenticationService.LogInAsync(user.Email, user.Password);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await authenticationService.LogOutAsync();
            return Ok();
        }
    }
}