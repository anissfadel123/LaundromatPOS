using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    public class ProductModel
    { 
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Barcode { get; set; }
        public Boolean isTaxable { get; set; }
    }
}

