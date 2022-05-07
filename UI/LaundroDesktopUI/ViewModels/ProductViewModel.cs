using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LaundroDesktopUI.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly NewSaleViewModel _newSaleViewModel;
        private readonly ProductModel _product;

        public ProductViewModel(ProductModel product, NewSaleViewModel newSaleViewModel)
        {
            _product = product;
            _newSaleViewModel = newSaleViewModel;
            AddProductCommand = new AddProductCommand(_newSaleViewModel);

        }

        public ProductModel Product => _product;

        public string Id => _product.Id.ToString();

        public string ProductName => _product.ProductDescription;

        public decimal Price => Convert.ToDecimal(_product.Price);

        public string Barcode => _product.Barcode;

        public string ProductImageSource => $"{Environment.CurrentDirectory}\\{_product.ImageLocation}";

        public ICommand AddProductCommand { get; }
    }
    
}
