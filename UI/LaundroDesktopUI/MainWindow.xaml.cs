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

namespace LaundroDesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                ChangeWindowState();
            }

        }

        // Change Window state to Normal / Minimize on Mouse Double Click
        private void ChangeWindowState()
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }


        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PaymentModel.IsOpen = false;
        }


        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            registerCustomerView.RegisterModal.IsOpen = true;
        }

        private void CashBtn_Click(object sender, RoutedEventArgs e)
        {
            PaymentModel.IsOpen = false;
            cashInputView.cashInputModal.IsOpen = true;
        }
    }
}
