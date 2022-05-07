using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class AddNewProductCommand : AsyncCommandBase
    {
        private AddNewProductViewModel _addNewProductVM;

        public AddNewProductCommand(AddNewProductViewModel addNewProductVM)
        {
            _addNewProductVM = addNewProductVM;
            _addNewProductVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _addNewProductVM.AddNewProductAsync();
        }
        public override bool CanExecute(object parameter)
        {
            return _addNewProductVM.CanAddNewProduct && base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addNewProductVM.CanAddNewProduct))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
