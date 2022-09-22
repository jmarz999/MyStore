using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var data = await productAppService.GetAllAsync();

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var data = await productAppService.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await productAppService.DeleteAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CreateProductDto product)
        {
            await productAppService.AddAsync(product);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(ProductDto product)
        {
            await productAppService.UpdateAsync(product);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> GetByIdsAsync(ProductIdsInput input)
        {
            var data = await productAppService.GetByIdsAsync(input.ProductIds);

            return Ok(data);
        }

        [HttpGet]
        public ActionResult GetManifactureres()
        {
            var data = productAppService.GetManifactureres();

            return Ok(data);
        }

        [HttpGet]
        public ActionResult GetCategory()
        {
            var data = productAppService.GetCategory();

            return Ok(data);
        }
    }
}