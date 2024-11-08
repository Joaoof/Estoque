using ES.Services.API.Aggregates.SuppliersAggregates.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ES.Application.API.Controllers
{
    [ApiController]
    [Route("Suppliers")]
    public class SuppliersController : Controller
    {
        private readonly ISuppliersAppService _suppliersAppService;

        public SuppliersController(ISuppliersAppService suppliersAppService)
        {
            _suppliersAppService = suppliersAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInformationAllSuppliers()
        {
            var all = await _suppliersAppService.GetInformationAllSuppliers();

            if (all is null)
            {
                return NoContent();
            }

            return Ok(all);
        }
    }
}
