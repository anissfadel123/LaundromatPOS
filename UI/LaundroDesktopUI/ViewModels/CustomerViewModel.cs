using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private CustomerModel _customerModel;

        public CustomerViewModel()
        {
            Reset();
        }

        public string CustomerName
        {
            get => _customerModel.FirstName + " " + _customerModel.LastName;
        }

        public string PhoneNumber
        {
            get => _customerModel.Phone;
        }

        public int ID
        {
            get => _customerModel.Id;
        }

        public int Points
        {
            get => _customerModel.Points;
        }

        public void Reset()
        {
            if (_customerModel == null)
            {
                _customerModel = new CustomerModel();
            }
            _customerModel.FirstName = "Guest";
            _customerModel.LastName = "";
            _customerModel.Phone = "";
            _customerModel.Id = 0;
            _customerModel.Points = 0;
            OnPropertyChanged(nameof(CustomerName));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(ID));
            OnPropertyChanged(nameof(Points));
        }

        public void SetCustomer(CustomerModel customer)
        {
            _customerModel = customer;
            OnPropertyChanged(nameof(CustomerName));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(ID));
            OnPropertyChanged(nameof(Points));
        }
    }
}
