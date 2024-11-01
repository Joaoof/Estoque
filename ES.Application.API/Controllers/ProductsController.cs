﻿using ES.Domain.API.Models;
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

        [HttpGet("{name}")]
        public async Task<IActionResult> GetInformationProduct(string name)
        {
            var products = await _productsAppService.GetInformationProduct(name);

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpGet()]
        public async Task<IActionResult> GetInformationAllProducts()
        {
            var productsAll = await _productsAppService.GetInformationAllProducts();

            if (productsAll == null)
            {
                return NoContent();
            }

            return Ok(productsAll);
        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> RegisterProduct(ProductsModel productsModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var register = await _productsAppService.RegisterProduct(productsModel);

            if (register is null) return BadRequest();

            return Ok(register);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> UpdateProduct(ProductsModel productsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna BadRequest se o modelo não for válido
            }

            var updateSucess = await _productsAppService.UpdateProduct(productsModel);
            
            if(!updateSucess)
            {
                return NoContent();
            }

            return Ok(updateSucess);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var delete = await _productsAppService.DeleteProduct(id);

            if (delete is null) return NoContent();

            return Ok(delete);
        }
    }
}
