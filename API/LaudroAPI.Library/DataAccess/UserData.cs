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
    public class UserData
    {
        private readonly IConfiguration _config;
        public UserData(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<UserModel>> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var output = await sql.LoadDataAsync<UserModel, dynamic>("dbo.spUserLookup", new { Id = Id }, "LaundroData");
            return output;
        }
    }
}
