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
    public class ProductViewModel : ViewModelBase
    {
        NewSaleViewModel _newSaleViewModel;
        private readonly ProductModel _product;
        public ProductModel Product => _product;

        public string Id => _product.Id.ToString();
        public string ProductName => _product.ProductName;
        public decimal Price => Convert.ToDecimal(_product.Price);
        public ProductViewModel(ProductModel product, NewSaleViewModel newSaleViewModel)
        {
            _product = product;
            _newSaleViewModel = newSaleViewModel;
            AddProductCommand = new AddProductCommand(_newSaleViewModel);

        }
        public ICommand AddProductCommand { get; }
    }
    
}
