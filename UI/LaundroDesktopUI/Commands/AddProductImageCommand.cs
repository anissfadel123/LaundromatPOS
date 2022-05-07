using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class AddProductImageCommand : CommandBase
    {
        private AddNewProductViewModel _AddNewProductImageVM;

        public AddProductImageCommand(AddNewProductViewModel addNewProductImageVM)
        {
            _AddNewProductImageVM = addNewProductImageVM;
        }

        public override void Execute(object parameter)
        {
            _AddNewProductImageVM.AddProductImageToDestinationFile();
        }
    }
}
