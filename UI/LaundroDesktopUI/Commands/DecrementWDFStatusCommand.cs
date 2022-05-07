using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    class DecrementWDFStatusCommand : AsyncCommandBase
    {
        private readonly IWdfEndpoint _wdfEndPoint;
        private readonly CleanViewModel _cleanVM;
        private readonly WdfCardViewModel _wdfCardVM;
        public DecrementWDFStatusCommand(IWdfEndpoint wdfEndpoint, WdfCardViewModel wdfCardVM, CleanViewModel cleanVM)
        {
            _wdfEndPoint = wdfEndpoint;
            _wdfCardVM = wdfCardVM;
            _cleanVM = cleanVM;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            int id = (int)parameter;

            await _wdfEndPoint.DecrementStatus(id);
            await _cleanVM.LoadWdfAsync();


        }
    }
}
