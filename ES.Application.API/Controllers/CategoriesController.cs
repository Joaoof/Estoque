using ES.Services.API.Aggregates.CategoriesAggregates.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{

    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesAppService _categoriesAppService;

        public CategoriesController(ICategoriesAppService categoriesAppService)
        {
            _categoriesAppService = categoriesAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoriesAppService.GetAllCategoriesAsync();
            return Ok(categories);
        }
    }
}
