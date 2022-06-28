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
using Microsoft.AspNetCore.Authorization;

namespace LaundroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
            CustomerData data = new(_config);
            IEnumerable<CustomerDto> customers = await data.GetAllCustomersAsync();
            return Ok(customers);
        }


        // Get: api/Customer/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            CustomerData data = new CustomerData(_config);
            CustomerDto customer = await data.GetCustomerByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> FilterCustomers(string id, string name)
        {
            CustomerData data = new CustomerData(_config);
            IEnumerable<CustomerDto> customers = await data.GetAllCustomersAsync();

            if (!string.IsNullOrEmpty(id))
            {
                customers = customers.Where(c => c.Id.ToString().Contains(id));
            }

            if (!string.IsNullOrEmpty(name))
            {
                customers = customers.Where(c => (c.FirstName + " " + c.LastName).ToLower().Contains(name.ToLower()));
            }

            return Ok(customers);


        }

        [HttpGet("contains/{str}")]
        public async Task<IActionResult> GetCustomerContain(string str)
        {
            CustomerData data = new(_config);
            IEnumerable<CustomerDto> customers = await data.GetAllCustomersAsync();
            List<CustomerNameAndIdDto> result = new();
            foreach (CustomerDto customer in customers)
            {
                string name = customer.FirstName + " " + customer.LastName + " (" + customer.Id + ")";
                if (name.Contains(str, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(new CustomerNameAndIdDto(name, customer.Id));
                }
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerAsync(CreateCustomerDto customerDto)
        {
            CustomerData data = new(_config);
            int id = await data.SaveCustomerRecordReturnIdAsync(customerDto);
            return CreatedAtAction("GetCustomer", new { id }, new { id });
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            CustomerData data = new(_config);

            bool exist = (await data.GetCustomerByIdAsync(id)) != null;

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
            CustomerData data = new(_config);
            bool exist = (await data.GetCustomerByIdAsync(customer.Id)) != null;
            if (!exist)
            {
                return NotFound();
            }
            await data.UpdateCustomerAsync(customer);
            return NoContent();
        }

    }
}
