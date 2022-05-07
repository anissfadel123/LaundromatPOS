using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class RegisterCustomerViewModel : ViewModelBase, IModal
    {
        private bool _isOpen;
        private readonly ICustomerEndpoint _customerEndpoint;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _address;

        public RegisterCustomerViewModel(ICustomerEndpoint customerEndpoint)
        {
            _customerEndpoint = customerEndpoint;
            SubmitCommand = new AddCustomerCommand(_customerEndpoint, this);
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

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(CanRegisterCustomer));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(CanRegisterCustomer));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
                OnPropertyChanged(nameof(CanRegisterCustomer));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand StatusButton { get; }
        public ICommand CloseCommand { get; }

        private bool HasFirstName => FirstName != null && FirstName.Length > 0;
        private bool HasLastName => LastName != null && LastName.Length > 0;
        private bool HasPhoneNumber => Phone != null && Phone.Length > 0;
        public bool CanRegisterCustomer => HasFirstName && HasLastName && HasPhoneNumber;
    }
}
