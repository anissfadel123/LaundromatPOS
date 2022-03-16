using LaundroAPI.Library.DataAccess;
using LaundroAPI.Library.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductsController(IConfiguration config)
        {
            _config = config;
        }

        // Get: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetAllProductssAsync()
        {
            ProductData data = new ProductData(_config);
            var products = await data.GetAllProductsAsync();
            return Ok(products);
        }


        // Get: api/Customer/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            ProductData data = new ProductData(_config);
            var product = await data.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync(CreateProductDto product)
        {
            ProductData data = new ProductData(_config);
            var id = await data.SaveProductReturnIdAsync(product);

            return CreatedAtAction("GetProduct", new { Id = id }, product);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            ProductData data = new ProductData(_config);

            var exist = (await data.GetProductByIdAsync(id)) != null;

            if (!exist)
            {
                return NotFound();
            }

            await data.DeleteProductAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutProductAsync(ProductDto customer)
        {
            ProductData data = new ProductData(_config);
            var exist = (await data.GetProductByIdAsync(customer.Id)) != null;
            if (!exist)
            {
                return NotFound();
            }
            await data.UpdateProductAsync(customer);
            return NoContent();

        }
    }

}
