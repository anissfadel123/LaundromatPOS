﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    public class ProductModel
    { 
        public int Id { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public Boolean IsTaxable { get; set; }
        public string ImageLocation { get; set; }
    }
}

