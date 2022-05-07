using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class CloseCurrent_OpenNewModalCommand<T> : CommandBase where T : IModal
    {
        private IModal _currentModal;
        public CloseCurrent_OpenNewModalCommand(T currentModal)
        {
            _currentModal = currentModal;
        }
        public override void Execute(object parameter)
        {
            var newModal = parameter as IModal;
            if(newModal != null)
            {
                _currentModal.IsOpen = false;
                newModal.IsOpen = true;
            }
            

        }
    }
}
