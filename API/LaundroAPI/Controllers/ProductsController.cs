using LaundroAPI.Library.DataAccess;
using LaundroAPI.Library.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductsController(IConfiguration config)
        {
            _config = config;
        }

        // Get: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            ProductData data = new(_config);
            IEnumerable<ProductDto> products = await data.GetAllProductsAsync();
            return Ok(products);
        }


        // Get: api/Products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            ProductData data = new(_config);
            ProductDto product = await data.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        //// Get api/Product/Barcode/5543534676324
        //[HttpGet("Barcode/{barcode}")]
        //public async Task<IActionResult> GetProductAsync(string barcode)
        //{
        //    ProductData data = new ProductData(_config);
        //    var product = await data.GetProductByBarcodeAsync(barcode);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        // Post: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProductAsync(CreateProductDto product)
        {
            ProductData data = new(_config);
            int id = await data.SaveProductReturnIdAsync(product);
            return CreatedAtAction("GetProduct", new { Id = id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            ProductData data = new(_config);
            bool exist = (await data.GetProductByIdAsync(id)) != null;
            if (!exist)
            {
                return NotFound();
            }
            await data.DeleteProductAsync(id);
            return NoContent();
        }

        // Put: api/Products
        [HttpPut]
        public async Task<IActionResult> PutProductAsync(ProductDto customer)
        {
            ProductData data = new(_config);
            bool exist = (await data.GetProductByIdAsync(customer.Id)) != null;
            if (!exist)
            {
                return NotFound();
            }
            await data.UpdateProductAsync(customer);
            return NoContent();
        }
    }

}
