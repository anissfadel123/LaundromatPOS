using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Commands
{
    public class AddProductCommand : CommandBase
    {
        private readonly NewSaleViewModel _newSaleViewModel;

        public AddProductCommand(NewSaleViewModel newSaleViewModel)
        {
            _newSaleViewModel = newSaleViewModel;
            _newSaleViewModel.PropertyChanged += OnViewPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            _newSaleViewModel.AddProduct(Convert.ToInt32(parameter));
            
        }

        private void OnViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            OnCanExecutedChanged();

        }
    }
}
