using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaundroDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for NewSaleView.xaml
    /// </summary>
    public partial class NewSaleView : UserControl
    {
        public NewSaleView()
        {
            InitializeComponent();
        }

        //private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    var newSaleVM = this.DataContext as NewSaleViewModel;
        //    var comboBox = (sender as ComboBox);
        //    if (e.Key >= Key.A && e.Key<=Key.Z || e.Key >= Key.D0 && e.Key <= Key.D9) 
        //    {
        //        _ = newSaleVM.GetCustomerContains();
        //        comboBox.IsDropDownOpen = true;
        //    }
        //    else if(e.Key == Key.Enter)
        //    {
        //        newSaleVM.CustomerSearch = "";
        //        comboBox.Focusable = false;
        //    }

        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await (this.DataContext as NewSaleViewModel).LoadProductAsync();
        }

        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var parentWindow = Window.GetWindow(this) as MainWindow;
        //    if(parentWindow != null)
        //    {
        //        parentWindow.PaymentModel.IsOpen = true;
        //    }
        //}
    }
}
