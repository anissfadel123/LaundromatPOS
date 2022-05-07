using LaundroAPI.Library.DataAccess;
using LaundroAPI.Library.Dtos;
using LaundroAPI.Library.Models;
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
    public class WdfController : ControllerBase
    {
        private readonly IConfiguration _config;
        public WdfController(IConfiguration config)
        {
            _config = config;
        }

        // Get: /api/Wdf
        [HttpGet]
        public async Task<IActionResult> GetAllWdfAsync()
        {
            WdfData data = new WdfData(_config);
            IEnumerable<WdfDto> wdfList = await data.GetAllWdfsAsync();
            return Ok(wdfList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWdfAsync(int id)
        {
            WdfData data = new(_config);
            WdfDto wdf = await data.GetWdfByIdAsync(id);
            return wdf == null ? NotFound() : Ok(wdf);
        }

        // Post: /api/Wdf
        [HttpPost]
        public async Task<IActionResult> PostWdfAsync([FromBody] CreateWdfDto wdfDto)
        {
            WdfData data = new(_config);
            WdfModel wdf = new()
            {
                CustomerId = wdfDto.CustomerId,
                ServiceId = wdfDto.ServiceId,
                Preferences = wdfDto.Preferences,
                Total = wdfDto.Total,
                ReadyBy = wdfDto.ReadyBy,
                Paid = wdfDto.Paid,
            };
            int id = await data.SaveWdfAsync(wdf);
            return CreatedAtAction("GetWdf", new { Id = id }, new { Id = id });
        }

        [HttpPut("IncrementStatus")]
        public async Task<IActionResult> IncrementWdfStatus([FromBody]int id)
        {
            WdfData data = new(_config);
            WdfDto wdf = await data.GetWdfByIdAsync(id);
            if (wdf == null)
            {
                return NotFound();
            }
            await data.IncrementWdfStatus(id);
            wdf = await data.GetWdfByIdAsync(id);
            return Ok(wdf);
        }


        [HttpPut("DecrementStatus")]
        public async Task<IActionResult> DecrementWdfStatus([FromBody] int id)
        {
            WdfData data = new(_config);
            WdfDto wdf = await data.GetWdfByIdAsync(id);
            if (wdf == null)
            {
                return NotFound();
            }
            await data.DecrementWdfStatus(id);
            wdf = await data.GetWdfByIdAsync(id);
            return Ok(wdf);
        }

    }
}
