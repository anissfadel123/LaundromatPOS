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
    public class SideBarViewModel : ViewModelBase, IModal
    {
        private bool _isOpen;
        private readonly IAPIHelper _apiHelper;

        public SideBarViewModel(IAPIHelper apiHelper, NewSaleViewModel newSaleVM, LoginViewModel loginVM)
        {
            _apiHelper = apiHelper;
            LogOutCommand = new LogOutCommand(_apiHelper, newSaleVM, loginVM, this);
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
        public ICommand LogOutCommand { get; }
    }
}
