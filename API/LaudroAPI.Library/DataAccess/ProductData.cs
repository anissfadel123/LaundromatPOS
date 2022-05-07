using LaundroAPI.Library.Dtos;
using LaundroAPI.Library.Internal.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.DataAccess
{
    public class ProductData
    {
        private readonly IConfiguration _config;
        public ProductData(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.LoadDataAsync<ProductDto, dynamic>("dbo.spProducts_GetAll", new { }, "LaundroData");

        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var output = await sql.LoadDataAsync<ProductDto, dynamic>("dbo.spProducts_GetProduct",
                new { Id = id }, "LaundroData");
            return output.FirstOrDefault();
        }        
        //public async Task<ProductDto> GetProductByBarcodeAsync(string barcode)
        //{
        //    SqlDataAccess sql = new SqlDataAccess(_config);
        //    var output = await sql.LoadDataAsync<ProductDto, dynamic>("dbo.spProducts_GetProductByBarcode",
        //        new { Barcode = barcode }, "LaundroData");
        //    return output.FirstOrDefault();
        //}
        
        public async Task DeleteProductAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            await sql.SaveDataAsync("dbo.spProducts_DeleteProduct", new { id }, "LaundroData");
        }
        public async Task<int> SaveProductReturnIdAsync(CreateProductDto product)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            return await sql.SaveDataReturnIdAsync("dbo.spProducts_Insert", product, "LaundroData");
        }

        public async Task UpdateProductAsync(ProductDto product)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            await sql.SaveDataAsync("dbo.spProducts_UpdateProduct", product, "LaundroData");
        }
    }
}
