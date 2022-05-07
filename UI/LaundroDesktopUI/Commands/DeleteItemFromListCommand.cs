using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class DeleteItemFromListCommand : CommandBase
    {
        private readonly NewSaleViewModel _newSaleVM;
        public DeleteItemFromListCommand(NewSaleViewModel newSaleVM)
        {
            _newSaleVM = newSaleVM;
        }
        public override void Execute(object parameter)
        {
            var item = parameter as CustomerProductViewModel;
            _newSaleVM.RemoveItemFromList(item);
        }
    }
}
