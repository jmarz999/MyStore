using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.AuthHelpers;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderAppService orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            this.orderAppService = orderAppService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllAsync()
        {
            var data = await orderAppService.GetAllAsync();

            return Ok(data);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var data = await orderAppService.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await orderAppService.DeleteAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CreateOrderDto order)
        {
            await orderAppService.AddAsync(order);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateAsync(OrderDto order)
        {
            await orderAppService.UpdateAsync(order);

            return Ok();
        }
    }
}