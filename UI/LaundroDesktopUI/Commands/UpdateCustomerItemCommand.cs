using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class UpdateCustomerItemCommand : CommandBase
    {
        private EditItemViewModel _editItemVM;
        private NewSaleViewModel _newSaleVM;
        public UpdateCustomerItemCommand(EditItemViewModel editItemVM, NewSaleViewModel newSaleVM)
        {
            _editItemVM = editItemVM;
            _newSaleVM = newSaleVM;
            _editItemVM.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            _editItemVM.CustomerProductVM.Quantity = _editItemVM.Quantity;
            _editItemVM.CustomerProductVM.Discount = _editItemVM.Discount;
            _editItemVM.IsOpen = false;
            _newSaleVM.UpdateBindingTotal();
        }
        public override bool CanExecute(object parameter)
        {
            return _editItemVM.CanUpdateItem && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_editItemVM.CanUpdateItem))
            {
                OnCanExecutedChanged();
            }
        }
        //&& _editItemVM.Discount >= 0 && 
        //        _editItemVM.Discount <= 100
    }
}
