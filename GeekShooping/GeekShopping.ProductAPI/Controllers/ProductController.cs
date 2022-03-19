﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            if (products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(int id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO product)
        {
            if (product == null) return BadRequest();
            return Ok(await _repository.Create(product));
        }
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO product)
        {
            if (product == null) return BadRequest();
            return Ok(await _repository.Update(product));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }


    }
}
