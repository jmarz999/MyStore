using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Services;

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
            var response = await authenticationService.LogInAsync(user.Email, user.Password);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await authenticationService.LogOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}