using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class AddProductByBarcodeCommand : CommandBase
    {
        private NewSaleViewModel _newSaleVM;

        public AddProductByBarcodeCommand(NewSaleViewModel newSaleVM)
        {
            _newSaleVM = newSaleVM;
        }

        public override void Execute(object parameter)
        {
            _newSaleVM.AddProductByBarcode();
        }
    }
}
