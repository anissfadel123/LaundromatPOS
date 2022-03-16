using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.Dtos
{
    public record ProductDto(int Id, string ProductName, decimal Price, string Barcode, bool IsTaxable, decimal TaxRate);
    public record CreateProductDto(string ProductName, decimal Price, string Barcode, bool IsTaxable, decimal TaxRate);
}
