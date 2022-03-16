using Dapper;
using LaundroAPI.Library.Internal.DataAccess;
using LaundroAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundroAPI.Library.Dtos;

namespace LaundroAPI.Library.DataAccess
{
    public class CustomerData
    {
        private readonly IConfiguration _config;
        public CustomerData(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.LoadDataAsync<CustomerDto, dynamic>("dbo.spCustomers_GetAll", new {}, "LaundroData");
            
        }
        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var output = await sql.LoadDataAsync<CustomerDto, dynamic>("dbo.spCustomers_GetCustomer",
                new { Id = id }, "LaundroData");
            return output.FirstOrDefault();
        }
        public async Task DeleteCustomerAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            await sql.SaveDataAsync("dbo.spCustomers_DeleteCustomer", new { id }, "LaundroData");  
        }
        public async Task<int> SaveCustomerRecordReturnIdAsync(CreateCustomerDto cust)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.SaveDataReturnIdAsync("dbo.spCustomers_Insert", cust, "LaundroData");
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            await sql.SaveDataAsync("dbo.spCustomers_UpdateCustomer", customer, "LaundroData");
        }

    }
}
