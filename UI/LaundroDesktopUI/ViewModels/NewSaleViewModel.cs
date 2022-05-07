using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.Services;
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

        private readonly CustomerViewModel _customerViewModel;
        private readonly IProductEndpoint _productEndpoint;
        private readonly ICustomerEndpoint _customerEndpoint;
        private string _barcode;
        private bool _isRetail = true, _isWDF, _isBedding, _isDryCleaning;
        private ObservableCollection<ProductViewModel> _products;
        private readonly ObservableCollection<CustomerProductViewModel> _customerProducts;
        private readonly IEnumerable<CustomerSearchModel> _customerSearches = new List<CustomerSearchModel>();

        public NewSaleViewModel(IProductEndpoint productEndpoint, ICustomerEndpoint customerEndpoint, CustomerViewModel customerViewModel)
        {

            AddProductCommand = new AddProductCommand(this);
            _customerProducts = new ObservableCollection<CustomerProductViewModel>();
            _productEndpoint = productEndpoint;
            _customerEndpoint = customerEndpoint;
            _customerViewModel = customerViewModel;
            AddProductByBarcodeCommand = new AddProductByBarcodeCommand(this);

        }

        public CustomerViewModel CustomerVM => _customerViewModel;

        public ObservableCollection<ProductViewModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public IEnumerable<CustomerProductViewModel> CustomerProducts => _customerProducts;

        public decimal SubTotal => CustomerProducts.Sum(p => p.Amount);

        public decimal Tax => 0;

        public decimal GrandTotal => SubTotal + Tax;

        public bool IsRetail
        {
            get => _isRetail;
            set
            {
                _isRetail = value;
                if (value)
                {
                    IsWDF = false;
                    IsBedding = false;
                    IsDryCleaning = false;
                }
                OnPropertyChanged(nameof(IsRetail));
            }
        }

        public bool IsWDF
        {
            get => _isWDF;
            set
            {
                _isWDF = value;
                if (value)
                {
                    IsRetail = false;
                    IsBedding = false;
                    IsDryCleaning = false;
                }
                OnPropertyChanged(nameof(IsWDF));
            }
        }

        public bool IsBedding
        {
            get => _isBedding;
            set
            {
                _isBedding = value;
                if (value)
                {
                    IsRetail = false;
                    IsWDF = false;
                    IsDryCleaning = false;
                }
                OnPropertyChanged(nameof(IsBedding));
            }
        }

        public bool IsDryCleaning
        {
            get => _isDryCleaning;
            set
            {
                _isDryCleaning = value;
                if (value)
                {
                    IsRetail = false;
                    IsWDF = false;
                    IsBedding = false;
                }
                OnPropertyChanged(nameof(IsDryCleaning));
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
        public ICommand AddProductCommand { get; }
        public ICommand AddProductByBarcodeCommand { get; }

        //private string _customerSearch = "";
        //public string CustomerSearch 
        //{
        //    get => _customerSearch;
        //    set
        //    {
        //        _customerSearch = value;
        //        OnPropertyChanged(CustomerSearch);
        //    }
        //}

        public void AddProduct(int id)
        {
            CustomerProductViewModel customerProduct = _customerProducts.Where(p => p != null && p.Id == id).FirstOrDefault();

            if (customerProduct == null)
            {
                ProductViewModel productVM = Products.Where(p => p.Id.Equals(id.ToString())).FirstOrDefault();
                customerProduct = new CustomerProductViewModel(productVM.Product, this);
                _customerProducts.Add(customerProduct);
            }

            customerProduct.Add(1);
            UpdateBindingTotal();
        }

        public void UpdateBindingTotal()
        {
            OnPropertyChanged(nameof(SubTotal));
            OnPropertyChanged(nameof(Tax));
            OnPropertyChanged(nameof(GrandTotal));
        }

        public void CancelTransaction()
        {
            _customerProducts.Clear();
            CustomerVM.Reset();
            OnPropertyChanged(nameof(CustomerProducts));
            UpdateBindingTotal();

        }
        public async Task LoadProductAsync()
        {
            var products = await _productEndpoint.GetAll();
            Products = new ObservableCollection<ProductViewModel>();

            foreach (var product in products)
            {
                _products.Add(new ProductViewModel(product, this));
            }
        }

        public void RemoveItemFromList(CustomerProductViewModel item)
        {
            _customerProducts.Remove(item);
            OnPropertyChanged(nameof(CustomerProducts));
            UpdateBindingTotal();
        }

        public async Task<CustomerModel> GetCustomerAsync(int id)
        {
            return await _customerEndpoint.Get(id);
        }

        public IEnumerable<string> CustomerSearches
        {
            get
            {
                List<string> customers = new List<string>();
                foreach (var c in _customerSearches)
                {
                    customers.Add(c.FullnameWithId);
                }
                return customers;
            }
        }

        public void AddProductByBarcode()
        {
            string id = Products.FirstOrDefault(
                (p) => {
                    if (p.Barcode == null) return false;
                    return p.Barcode.Equals(Barcode);
                })
                .Id;
            AddProduct(Int32.Parse(id));
            Barcode = "";
        }

        public void ClearProducts()
        {
            Products.Clear();

        }
    }
}
