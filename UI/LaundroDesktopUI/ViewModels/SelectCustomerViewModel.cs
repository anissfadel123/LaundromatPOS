using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class SelectCustomerViewModel : ViewModelBase, IModal
    {
        private bool _isOpen;
        private string _id;
        private string _name;
        private readonly ICustomerEndpoint _customerEndpoint;
        private readonly NewSaleViewModel _newSaleVM;
        private ObservableCollection<CustomerModel> _customerList = new ObservableCollection<CustomerModel>();

        public SelectCustomerViewModel(ICustomerEndpoint customerEndpoint, NewSaleViewModel newSaleVM)
        {
            _customerEndpoint = customerEndpoint;
            _newSaleVM = newSaleVM;
            FilterCustomersCommand = new FilterCustomerCommand(this);
            SelectCustomerCommand = new SelectCustomerCommand(this);
        }

        public ObservableCollection<CustomerModel> CustomerList
        {
            get => _customerList;
            set
            {
                _customerList = value;
                OnPropertyChanged(nameof(CustomerList));
            }
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ICommand FilterCustomersCommand { get; }
        public ICommand SelectCustomerCommand { get; }

        public void ResetCustomerList(IEnumerable<CustomerModel> customers)
        {
            if (CustomerList == null)
            {
                CustomerList = new ObservableCollection<CustomerModel>();
            }
            else
            {
                CustomerList.Clear();
            }

            foreach (CustomerModel c in customers)
            {
                CustomerList.Add(c);
            }
        }

        public async Task FilterCustomers()
        {
            IEnumerable<CustomerModel> customers = await _customerEndpoint.FilterCustomer(ID, Name);
            ResetCustomerList(customers);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            _newSaleVM.CustomerVM.SetCustomer(customer);
        }
    }
}
