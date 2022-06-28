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
    public class PrintReceiptViewModel : ViewModelBase, IModal
    {
        private NewSaleViewModel _newSaleVM;
        private CashInputViewModel _cashInputVM;
        private bool _isOpen = false;

        public PrintReceiptViewModel(NewSaleViewModel newSaleVM, CashInputViewModel cashInputVM)
        {
            _newSaleVM = newSaleVM;
            _cashInputVM = cashInputVM;
            PrintReceiptCommand = new CreateAndPrintReceiptCommand(this);
            
            
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
                if (value)
                {
                    OnPropertyChanged(nameof(CustomerName));
                    OnPropertyChanged(nameof(CustomerID));
                    OnPropertyChanged(nameof(CustomerProducts));
                    OnPropertyChanged(nameof(SubTotal));
                    OnPropertyChanged(nameof(Tax));
                    OnPropertyChanged(nameof(Total));
                    OnPropertyChanged(nameof(Cash));
                    OnPropertyChanged(nameof(Change));
                }
            }
        }
        public IEnumerable<CustomerProductViewModel> CustomerProducts => _newSaleVM.CustomerProducts;
        public decimal Cash => String.IsNullOrEmpty(_cashInputVM.CashAmount) ? 0 : Decimal.Parse(_cashInputVM.CashAmount) ;
        public decimal Change => Cash - Total;
        public decimal SubTotal => _newSaleVM.SubTotal;
        public decimal Tax => _newSaleVM.Tax;
        public decimal Total => _newSaleVM.GrandTotal;
        public string BusinessName => "Six Bro Laundromat";
        public string BusinessAddress => "8115 Flatlands Avenue";
        public string BusinessCity => "Brooklyn";
        public string BusinessState => "NY";
        public string BusinessZipCode => "11235";
        public string BusinessNumber => "(929) 123-4567";
        public string CustomerName => _newSaleVM.CustomerVM.CustomerName;
        public int CustomerID => _newSaleVM.CustomerVM.ID;
        public string BusinessCityStateZip => BusinessCity + ", " + BusinessState + " " + BusinessZipCode;

        public ICommand PrintReceiptCommand { get; }


        
    }
}
