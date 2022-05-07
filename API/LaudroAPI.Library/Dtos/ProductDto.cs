using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.Dtos
{
    public record ProductDto(int Id, string ProductDescription, decimal Price, string Barcode, bool IsTaxable, decimal TaxRate, string ImageLocation);
    public record CreateProductDto(string ProductDescription, decimal Price, string Barcode, bool IsTaxable, decimal TaxRate, string ImageLocation);
}
