using LaundroAPI.Library.Dtos;
using LaundroAPI.Library.Internal.DataAccess;
using LaundroAPI.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.DataAccess
{
    public class WdfData
    {
        private readonly IConfiguration _config;
        public WdfData(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<WdfDto>> GetAllWdfsAsync()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.LoadDataAsync<WdfDto, dynamic>("dbo.spWdfs_GetAll", new { }, "LaundroData");

        }
        public async Task<WdfDto> GetWdfByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var output = await sql.LoadDataAsync<WdfDto, dynamic>("dbo.spWdfs_GetWdf",
                new { Id = id }, "LaundroData");
            return output.FirstOrDefault();
        }
        public async Task DeleteWdfByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            await sql.SaveDataAsync("dbo.spWdfs_DeleteWdf", new { id }, "LaundroData");
        }
        public async Task<int> SaveWdfAsync(WdfModel wdf)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.SaveDataReturnIdAsync("dbo.spWdfs_Insert", wdf , "LaundroData");
        }

        public async Task UpdateWdfAsync(WdfDto wdf)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            await sql.SaveDataAsync("dbo.spWdfs_UpdateWdf", wdf, "LaundroData");
        }

        public async Task IncrementWdfStatus(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            await sql.SaveDataAsync("dbo.spWdfs_IncrementWdfStatus", new { Id = id }, "LaundroData");
        }

        public async Task DecrementWdfStatus(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            await sql.SaveDataAsync("dbo.spWdfs_DecrementWdfStatus", new { Id = id }, "LaundroData");
        }
    }
}

