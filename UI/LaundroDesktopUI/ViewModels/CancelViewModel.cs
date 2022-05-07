using LaundroDesktopUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class CancelViewModel : ViewModelBase, IModal
    {
        private bool _isOpen;

        public CancelViewModel(NewSaleViewModel newSaleVM)
        {
            CancelTransactionCommand = new CancelTransactionCommand(newSaleVM, this);
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
        public ICommand CancelTransactionCommand { get; }
    }
}
