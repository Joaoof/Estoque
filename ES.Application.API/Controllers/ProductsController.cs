using ES.Services.API.Aggregates.ProdutcsAggregates.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsAppService _productsAppService;

        public ProductsController(IProductsAppService productsAppServices)
        {
            _productsAppService = productsAppServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInformationProducts(int id)
        {
            var products = await _productsAppService.GetInformationProducts(id);

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }
    }
}
