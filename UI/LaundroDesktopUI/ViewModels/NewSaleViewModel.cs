using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class NewSaleViewModel : ViewModelBase
    {
        private ObservableCollection<ProductViewModel> _products;

        public string Hello { get; set; } = "Yessir";

        public ObservableCollection<ProductViewModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private ObservableCollection<CustomerProductViewModel> _customerProducts;
        

        public IEnumerable<CustomerProductViewModel> CustomerProducts => _customerProducts;


        public decimal SubTotal => CustomerProducts.Sum(p => p.Amount);

        public decimal Tax => 0;

        public decimal GrandTotal => SubTotal + Tax;
        public void AddProduct(int id)
        {
            CustomerProductViewModel customerProduct = _customerProducts.Where(p => p != null && p.Id == id).FirstOrDefault();

            if (customerProduct == null)
            {
                ProductViewModel productVM = Products.Where(p => p.Id.Equals(id.ToString())).FirstOrDefault();
                customerProduct = new CustomerProductViewModel(productVM.Product);
                _customerProducts.Add(customerProduct);
            }

            customerProduct.Add(1);

            OnPropertyChanged(nameof(SubTotal));
            OnPropertyChanged(nameof(Tax));
            OnPropertyChanged(nameof(GrandTotal));
        }

        private bool _isRetail=false;

        public bool IsRetail
        {
            get { return _isRetail; }
            set { 
                _isRetail = value;
                OnPropertyChanged("Products");
            }
        }

        private bool _isWDF = false;

        public bool IsWDF
        {
            get { return _isWDF; }
            set { _isWDF = value; }
        }

        private bool _isBedding = false;

        public bool IsBedding
        {
            get { return _isBedding; }
            set { _isBedding = value; }
        }

        private bool _isDryCleaning = false;

        public bool IsDryCleaning
        {
            get { return _isDryCleaning; }
            set { _isDryCleaning  = value; }
        }


        public bool isBedding = false;
        private bool isDryCleaning=false;
        private IProductEndpoint _productEndpoint;
        public NewSaleViewModel(IProductEndpoint product)
        {

            AddProductCommand = new AddProductCommand(this);
            _customerProducts = new ObservableCollection<CustomerProductViewModel>();
            _productEndpoint = product;
            
            
            _ = LoadProductAsync();
            
            //addTest();

        }
        
        private async Task LoadProductAsync()
        {
            
            var products = await _productEndpoint.GetAll();
            Products = new ObservableCollection<ProductViewModel>();

            foreach(var product in products)
            {
                // TODO dependency injection
                _products.Add(new ProductViewModel(product, this));
            }
        }       
        //private void addTest()
        //{
        //    ProductModel product1 = new ProductModel
        //    {
        //        Id = 1,
        //        Price = "5.0",
        //        isTaxable = true,
        //        Barcode = "123456789",
        //        ProductName = "Tide Detergent"

        //    };
        //    ProductModel product2 = new ProductModel
        //    {
        //        Id = 2,
        //        Price = "6.0",
        //        isTaxable = true,
        //        Barcode = "123456789",
        //        ProductName = "Tide Your Mom"

        //    };



        //        _products.Add(new ProductViewModel(product1, this));

        //        _products.Add(new ProductViewModel(product2, this));
            
        //    AddProduct(product1.Id);
        //    AddProduct(product1.Id);
        //    AddProduct(product1.Id);
        //    AddProduct(product2.Id);
        //    AddProduct(product2.Id);

        //}
        public ICommand AddProductCommand { get; }



    }
}
