using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundroDesktopUI.Services;
namespace LaundroDesktopUI.Commands
{
    public class NavigateCommand<TViewModel> : AsyncCommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            _navigationService.Navigate();
            if (parameter is CleanViewModel clean)
            {
               await clean.LoadWdfAsync();
            }
            else if (parameter is ReadyViewModel ready)
            {
                await ready.LoadWDFReadyListAsync();
            }
        }
    }

}
