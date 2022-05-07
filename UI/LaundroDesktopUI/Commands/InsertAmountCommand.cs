using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class InsertAmountCommand : CommandBase
    {
        private CashInputViewModel _cashInputVM;

        public InsertAmountCommand(CashInputViewModel cashInputVM)
        {
            _cashInputVM = cashInputVM;
        }

        public override void Execute(object parameter)
        {
            string amtStr = (parameter as String);
            var amtChar = amtStr[0];
            _cashInputVM.InsertAmount(amtChar);
        }
    }
}
