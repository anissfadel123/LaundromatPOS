using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class FilterCustomerCommand : AsyncCommandBase
    {
        private SelectCustomerViewModel _selectCustomerVM;

        public FilterCustomerCommand(SelectCustomerViewModel selectCustomerVM)
        {
            _selectCustomerVM = selectCustomerVM;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _selectCustomerVM.FilterCustomers();
        }
    }
}
