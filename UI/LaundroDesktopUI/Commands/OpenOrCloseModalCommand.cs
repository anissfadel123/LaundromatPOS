using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class OpenOrCloseModalCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var modal = parameter as IModal;
            if(modal != null)
            {
                modal.IsOpen = !modal.IsOpen;
            }
        }
    }
}
