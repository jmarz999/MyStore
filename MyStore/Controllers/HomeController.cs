using Microsoft.AspNetCore.Mvc;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        [HttpGet]

        public ActionResult Home()
        {
            return new RedirectResult("~/swagger");
        } 
    }

}
