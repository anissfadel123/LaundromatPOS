using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class SelectCustomerCommand : CommandBase
    {
        private SelectCustomerViewModel _selectCustomerVM;

        public SelectCustomerCommand(SelectCustomerViewModel selectCustomerVM)
        {
            _selectCustomerVM = selectCustomerVM;
        }

        public override void Execute(object parameter)
        {
            var customer = parameter as CustomerModel;
            if(customer != null)
            {
                _selectCustomerVM.InsertCustomer(customer);
            }
            _selectCustomerVM.IsOpen = false;
        }
    }
}
