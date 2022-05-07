using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAPIHelper _apiHelper;
        private readonly NewSaleViewModel _newSaleVM;
        private bool _isOpen = true;
        private string _username = "anissfadel123";
        private string _password = "Abc_123";
        private string _errorMessage = "";

        public LoginViewModel(IAPIHelper apiHelper, NewSaleViewModel newSaleVM)
        {
            _apiHelper = apiHelper;
            _newSaleVM = newSaleVM;
            LoginCommand = new LoginCommand(_newSaleVM, this);
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

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public async Task LoginAsync()
        {
            try
            {
                var result = await _apiHelper.Authenticate(Username, Password);
                ErrorMessage = "";

                await _apiHelper.GetLoggedInUserInfo(result.Token);
            }
            catch (Exception)
            {
                ErrorMessage = "Invalid username and/or password";
                throw new Exception("Invalid username and/or password");
            }
        }
    }
}
