using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class CancelTransactionCommand : CommandBase
    {
        private NewSaleViewModel _newSaleVM;
        private IModal _cancelModal;

        public CancelTransactionCommand(NewSaleViewModel newSaleVM, IModal cancelModal)
        {
            _newSaleVM = newSaleVM;
            _cancelModal = cancelModal;
        }

        public override void Execute(object parameter)
        {
            _newSaleVM.CancelTransaction();
            _cancelModal.IsOpen = false;
        }

    }
}
