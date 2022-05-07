using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private NewSaleViewModel _newSaleVM;
        private LoginViewModel _loginVM;

        public LoginCommand(NewSaleViewModel newSaleVM, LoginViewModel loginVM)
        {
            _newSaleVM = newSaleVM;
            _loginVM = loginVM;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _loginVM.LoginAsync();
                await _newSaleVM.LoadProductAsync();

                _loginVM.IsOpen = false;

            }
            catch
            {
                _loginVM.IsOpen = true;
            }
        }
    }
}
