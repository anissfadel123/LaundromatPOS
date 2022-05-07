using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class LogOutCommand : CommandBase
    {
        private IAPIHelper _apiHelper;
        private NewSaleViewModel _newSaleViewModel;
        private LoginViewModel _loginVM;
        private SideBarViewModel _sideBarVM;

        public LogOutCommand(IAPIHelper apiHelper, NewSaleViewModel newSaleVM, LoginViewModel loginVM, SideBarViewModel sidebarVM)
        {
            _apiHelper = apiHelper;
            _newSaleViewModel = newSaleVM;
            _loginVM = loginVM;
            _sideBarVM = sidebarVM;
        }

        public override void Execute(object parameter)
        {
            _apiHelper.LogOffUser();
            _newSaleViewModel.ClearProducts();
            _sideBarVM.IsOpen = false;
            _loginVM.IsOpen = true;
        }
    }
}
