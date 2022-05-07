using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class IncrementWDFStatusCommand : AsyncCommandBase
    {
        private readonly IWdfEndpoint _wdfEndPoint;
        private readonly CleanViewModel _cleanVM;
        public IncrementWDFStatusCommand(IWdfEndpoint wdfEndpoint, CleanViewModel cleanVM)
        {
            _wdfEndPoint = wdfEndpoint;
            _cleanVM = cleanVM;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            int id = (int) parameter;
            await _wdfEndPoint.IncrementStatus(id);
            await _cleanVM.LoadWdfAsync();
        }
    }
}
