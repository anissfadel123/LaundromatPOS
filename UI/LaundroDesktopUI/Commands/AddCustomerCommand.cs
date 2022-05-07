using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    class AddCustomerCommand : CommandBase
    {
        private ICustomerEndpoint _customerEndpoint;
        private RegisterCustomerViewModel _registerCustomer;
        public AddCustomerCommand(ICustomerEndpoint customerEndpoint, RegisterCustomerViewModel registerCustomer)
        {
            _customerEndpoint = customerEndpoint;
            _registerCustomer = registerCustomer;
            _registerCustomer.PropertyChanged += OnViewModelPropertyChanged;

        }
        public override void Execute(object parameter)
        {
            CustomerModel customer = new CustomerModel
            {
                FirstName = _registerCustomer.FirstName,
                LastName = _registerCustomer.LastName,
                Email = _registerCustomer.Email,
                Phone = _registerCustomer.Phone,
                Address = _registerCustomer.Address
            };

            _customerEndpoint.Post(customer);
            _registerCustomer.IsOpen = false;
        }
        public override bool CanExecute(object parameter)
        {
            return _registerCustomer.CanRegisterCustomer && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_registerCustomer.CanRegisterCustomer))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
