using LaundroDesktopUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class EditItemViewModel : ViewModelBase, IModal
    {
        private MainViewModel _mainVM;
        private bool _isOpen;
        private int _quantity = 0;
        private decimal _discount;

        public EditItemViewModel(MainViewModel mainViewModel, NewSaleViewModel newSaleViewModel)
        {
            _mainVM = mainViewModel;
            UpdateCustomerItemCommand = new UpdateCustomerItemCommand(this, newSaleViewModel);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                if (value)
                {
                    OnPropertyChanged(nameof(Quantity));
                    OnPropertyChanged(nameof(ItemInfo));
                    OnPropertyChanged(nameof(Discount));
                    OnPropertyChanged(nameof(Unit));
                }
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        public CustomerProductViewModel CustomerProductVM => _mainVM.selectedProductToEdit;

        public int Quantity
        {
            get
            {
                if(CustomerProductVM != null && _quantity == 0)
                {
                    _quantity = CustomerProductVM.Quantity;
                    OnPropertyChanged(nameof(CanUpdateItem));
                }
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(CanUpdateItem));
            }
        }

        public decimal Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                OnPropertyChanged(nameof(Discount));
                OnPropertyChanged(nameof(CanUpdateItem));
            }
        }

        public string ItemInfo
        {
            get
            {
                if(CustomerProductVM != null)
                {
                    return CustomerProductVM.ItemInfo;
                }
                return "";
            }
        }

        public decimal Unit
        {
            get
            {
                if(CustomerProductVM != null)
                {
                    return CustomerProductVM.Unit;
                }
                return 0;
            }
        }

        private bool HasQuantity => Quantity > 0;
        private bool HasCorrectDiscount => Discount >= 0 && Discount <= 100;
        public bool CanUpdateItem => HasQuantity && HasCorrectDiscount;
        public ICommand UpdateCustomerItemCommand { get; }

    }
}
