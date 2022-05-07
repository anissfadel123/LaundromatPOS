using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class AddNewProductViewModel : ViewModelBase, IModal
    {
        private IProductEndpoint _productEndpoint;
        private NewSaleViewModel _newSaleVM;
         private bool _isOpen = false;
        private string _description;
        private decimal _price;
        private string _barcode;
        private string _imageLocation;

        public AddNewProductViewModel(IProductEndpoint productEndpoint, NewSaleViewModel newSaleVM)
        {
            _productEndpoint = productEndpoint;
            _newSaleVM = newSaleVM;
            AddNewProductCommand = new AddNewProductCommand(this);
            AddProductImageCommand = new AddProductImageCommand(this);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        public string ProductDescription
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(ProductDescription));
                OnPropertyChanged(nameof(CanAddNewProduct));
            }
        }

        public decimal Price
        {
            get { return _price; }
            set { 
                _price = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CanAddNewProduct));
            }
        }

        public string Barcode
        {
            get => _barcode;
            set
            {
                _barcode = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }

        public string ImageLocation
        {
            get => _imageLocation;
            set
            {
                _imageLocation = value;
                OnPropertyChanged(nameof(ImageLocation));

            }
        }

        public string ImageFileName
        {
            get
            {
                if (ImageLocation != null)
                {
                    return System.IO.Path.GetFileName(ImageLocation);
                }
                return "";
            }
        }

        public bool CanAddNewProduct => !string.IsNullOrEmpty(ProductDescription) && Price > 0M;

        public ICommand AddProductImageCommand { get; }
        public ICommand AddNewProductCommand { get; }

        public async Task AddNewProductAsync()
        {
            var product = new ProductModel
            {
                ProductDescription = this.ProductDescription,
                Price = this.Price,
                Barcode = this.Barcode,
                ImageLocation = this.ImageLocation
            };
            await _productEndpoint.Post(product);

            await _newSaleVM.LoadProductAsync();
            IsOpen = false;
            
        }

        public void AddProductImageToDestinationFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == true)
            {
                string targetPath = "ProductImages";
                string fileName = dialog.FileName;
                ImageLocation = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileName(fileName));
                System.IO.Directory.CreateDirectory(targetPath);
                System.IO.File.Copy(fileName, ImageLocation, true);

                OnPropertyChanged(nameof(ImageFileName));

            }
        }

    }
}
