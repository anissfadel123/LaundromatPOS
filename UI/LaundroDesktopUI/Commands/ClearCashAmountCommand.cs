using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class ClearCashAmountCommand : CommandBase
    {
        private CashInputViewModel _cashInputVM;

        public ClearCashAmountCommand(CashInputViewModel cashInputVM)
        {
            _cashInputVM = cashInputVM;
        }

        public override void Execute(object parameter)
        {
            _cashInputVM.ClearCashAmount();
        }
    }
}
