using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class CustomerProductViewModel :ViewModelBase
    {
        private readonly ProductModel _product;
        private decimal _discount = 0;
        private int _quantity = 0;
        
        public CustomerProductViewModel(ProductModel product, NewSaleViewModel newSaleViewModel)
        {
            _product = product;
            DeleteItemCommand = new DeleteItemFromListCommand(newSaleViewModel);
        }

        public ProductModel Product => _product;

        public int Id => _product.Id;

        public int Quantity
        {
            get =>_quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Amount));
            }
        }
        public string ItemInfo => _product.ProductDescription;

        public decimal Discount {

            get =>_discount;
            set
            {
                _discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }

        public decimal Unit => _product.Price;

        public decimal Amount
        {
            get
            {
                decimal price = Convert.ToDecimal(_product.Price);
                decimal cost = price * Quantity;
                decimal discountPrice = price * _discount;
                return cost - discountPrice;
            }
        }

        public ICommand DeleteItemCommand { get; }
        public ICommand EditItemCommand { get; }

        public void Add(int amt)
        {
            Quantity += amt;
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Amount));
        }
    }
}
