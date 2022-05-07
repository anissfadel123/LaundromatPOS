using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.Models
{
    class ProductModel
    {
        public int Id { get; set; }
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string Barcode { get; set; }
        public string ImageLocation { get; set; }
        public Boolean isTaxable { get; set; }
    }
}
