using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class OpenEditModalCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        public OpenEditModalCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            _mainViewModel.selectedProductToEdit = parameter as CustomerProductViewModel;
            _mainViewModel.EditItemVM.IsOpen = true;
        }
    }
}
