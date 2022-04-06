using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.ViewModels
{
    public class CustomerProductViewModel :ViewModelBase
    {
        private readonly ProductModel _product;
        private decimal _discount = 0;

        public ProductModel Product => _product;
        public int Id => _product.Id;
        public int Qty { get; set; } = 0;
        public string ItemInfo => _product.ProductName;
        public string Discount => _discount.ToString();
        public string Unit => _product.Price;
        public decimal Amount
        {
            get
            {
                decimal price = Convert.ToDecimal(_product.Price);
                decimal cost = price * Qty;
                decimal discountPrice = price * _discount;
                return cost - discountPrice;
            }
        }


        public CustomerProductViewModel(ProductModel product)
        {
            _product = product;
        }

        public void Add(int amt)
        {
            Qty += amt;
            OnPropertyChanged(nameof(Qty));
            OnPropertyChanged(nameof(Amount));
            
        }
    }
}
