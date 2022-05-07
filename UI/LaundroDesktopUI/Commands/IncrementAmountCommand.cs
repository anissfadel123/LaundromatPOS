using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    class IncrementAmountCommand : CommandBase
    {
        private CashInputViewModel _cashInputVM;

        public IncrementAmountCommand(CashInputViewModel cashInputVM)
        {
            _cashInputVM = cashInputVM;
        }

        public override void Execute(object parameter)
        {
            var amtString = parameter as String;
            int amt = Int32.Parse(amtString);
            if(_cashInputVM != null && amt > 0)
            {
                _cashInputVM.IncrementAmount(amt);
            }
        }
    }
}
