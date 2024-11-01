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
        public async Task<IActionResult> GetInformationProducts(string name)
        {
            var products = await _productsAppService.GetInformationProducts(name);

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
        public async Task<IActionResult> RegisterProducts(ProductsModel productsModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var register = await _productsAppService.RegisterProducts(productsModel);

            if (register is null) return BadRequest();

            return Ok(register);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> UpdateProducts(ProductsModel productsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna BadRequest se o modelo não for válido
            }

            var updateSucess = await _productsAppService.UpdateProducts(productsModel);
            
            if(!updateSucess)
            {
                return NoContent();
            }

            return Ok(updateSucess);
        }
    }
}
