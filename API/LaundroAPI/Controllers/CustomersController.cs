using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaundroAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using LaundroAPI.Library.DataAccess;
using LaundroAPI.Library.Dtos;

namespace LaundroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CustomersController(IConfiguration config)
        {
            _config = config;
        }

       // Get: api/Customers
       [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            CustomerData data = new CustomerData(_config);
            var customers = await data.GetAllCustomersAsync();
            return Ok(customers);
        }


        // Get: api/Customer/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            CustomerData data = new CustomerData(_config);
            var customer = await data.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
       
        [HttpPost]
        public async Task<IActionResult> PostCustomerAsync(CreateCustomerDto customerDto)
        {
            CustomerData data = new CustomerData(_config);

            var id = await data.SaveCustomerRecordReturnIdAsync(customerDto);

            return CreatedAtAction("GetCustomer", new { id = id }, new { id = id });
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            CustomerData data = new CustomerData(_config);

            var exist = (await data.GetCustomerByIdAsync(id)) != null;

            if (!exist)
            {
                return NotFound();
            }

             await data.DeleteCustomerAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomerAsync(CustomerDto customer)
        {
            CustomerData data = new CustomerData(_config);
            var exist = (await data.GetCustomerByIdAsync(customer.Id)) != null;
            if (!exist)
            {
                return NotFound();
            }
            await data.UpdateCustomerAsync(customer);
            return NoContent();

        }

    }
}
