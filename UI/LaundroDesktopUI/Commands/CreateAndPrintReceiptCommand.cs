using LaundroDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LaundroDesktopUI.Commands
{
    public class CreateAndPrintReceiptCommand : CommandBase
    {
        private PrintReceiptViewModel _printReceiptVM;
        private Style lightText, boldText;

        public CreateAndPrintReceiptCommand(PrintReceiptViewModel printReceiptVM)
        {
            _printReceiptVM = printReceiptVM;

            lightText = new Style(typeof(TextBlock));
            lightText.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center));
            lightText.Setters.Add(new Setter(TextBlock.FontSizeProperty, 11.0));


            boldText = new Style(typeof(TextBlock));
            boldText.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold));
            boldText.Setters.Add(new Setter(TextBlock.FontSizeProperty, 11.0));
        }

        public override void Execute(object parameter)
        {
            PrintReceipt();
            _printReceiptVM.IsOpen = false;
        }
        private void PrintReceipt()
        {
            PrintDialog printDlg = new PrintDialog();
            
            
            FlowDocument doc = new FlowDocument();
            doc.PagePadding = new Thickness(0, 0, 0, 0);
            doc.Blocks.Add(new BlockUIContainer(CreateReceiptPanel()));
            doc.PageWidth = printDlg.PrintableAreaWidth;

            IDocumentPaginatorSource idpSource = doc;

            bool? print = printDlg.ShowDialog();
            if (print == true)
            {
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            }
        }

        private Panel CreateReceiptPanel()
        {
            StackPanel receiptPanel = new StackPanel();
            receiptPanel.Margin = new Thickness(0, 20, 0, 20);
            receiptPanel.Children.Add(new TextBlock() { Text = "Welcome to", Style = lightText });
            receiptPanel.Children.Add(new TextBlock() { Text = _printReceiptVM.BusinessName, Style = lightText });
            receiptPanel.Children.Add(new TextBlock() { Text = _printReceiptVM.BusinessAddress, Style = lightText });
            receiptPanel.Children.Add(new TextBlock() { Text = _printReceiptVM.BusinessCityStateZip, Style = lightText });
            receiptPanel.Children.Add(new TextBlock() { Text = _printReceiptVM.BusinessName, Style = lightText });
            receiptPanel.Children.Add(new TextBlock());
            receiptPanel.Children.Add(new TextBlock() { Text = $"Customer: {_printReceiptVM.CustomerName}", Style = boldText });
            receiptPanel.Children.Add(new TextBlock() { Text = $"Customer ID: {_printReceiptVM.CustomerID}", Style = boldText });
            receiptPanel.Children.Add(new TextBlock() { Text = "Date: Jun 22, 2022, 5:50:03 PM", Style = boldText });
            receiptPanel.Children.Add(new TextBlock() { Text = $"Invoice#: 1044", Style = boldText });
            receiptPanel.Children.Add(new TextBlock());
            receiptPanel.Children.Add(CreateCustomerProductsGridHeader());
            receiptPanel.Children.Add(CreateCustomerProductsPanel());
            receiptPanel.Children.Add(new TextBlock() { Text = "----------------------------------------------" });

            Grid subTotalGrid = new Grid();
            subTotalGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Left, Text = "SubTotal" });
            subTotalGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0,0,7,0),  Text = _printReceiptVM.SubTotal.ToString("C")});

            Grid taxGrid = new Grid();
            taxGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Left, Text = "Tax" });
            taxGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 7, 0), Text = _printReceiptVM.Tax.ToString("C") });

            Grid totalGrid = new Grid();
            totalGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Left, Text = "Total" });
            totalGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 7, 0), Text = _printReceiptVM.Total.ToString("C") });

            Grid cashGrid = new Grid();
            cashGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Left, Text = "Cash" });
            cashGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 7, 0), Text = _printReceiptVM.Cash.ToString("C") });

            Grid changeGrid = new Grid();
            changeGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Left, Text = "Change" });
            changeGrid.Children.Add(new TextBlock() { FontSize = 11.0, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 7, 0), Text = $"-{ _printReceiptVM.Change.ToString("C")}" });

            receiptPanel.Children.Add(subTotalGrid);
            receiptPanel.Children.Add(taxGrid);
            receiptPanel.Children.Add(totalGrid);
            receiptPanel.Children.Add(new TextBlock() { Text = "----------------------------------------------" });
            receiptPanel.Children.Add(cashGrid);
            receiptPanel.Children.Add(changeGrid);
            receiptPanel.Children.Add(new TextBlock() { TextAlignment = TextAlignment.Center, FontWeight = FontWeights.SemiBold, FontSize = 15.0, Margin = new Thickness(0,50,0,0), Text = "Thanks for your purchase!!!" });

            return receiptPanel;
        }

        private Grid CreateCustomerProductsGridHeader()
        {
            Grid header = new Grid();

            ColumnDefinition c1 = new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) };
            ColumnDefinition c2 = new ColumnDefinition() { Width = new GridLength(73, GridUnitType.Star) };
            ColumnDefinition c3 = new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Star) };
            header.ColumnDefinitions.Add(c1);
            header.ColumnDefinitions.Add(c2);
            header.ColumnDefinitions.Add(c3);

            TextBlock txtBlock1 = new TextBlock() { Text = "Q", Style = boldText };
            Grid.SetColumn(txtBlock1, 0);
            header.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock() { Text = "Description", Style = boldText, TextAlignment = TextAlignment.Center };
            Grid.SetColumn(txtBlock2, 1);
            header.Children.Add(txtBlock2);

            TextBlock txtBlock3 = new TextBlock() { Text = "Price", Style = boldText, TextAlignment = TextAlignment.Center };
            Grid.SetColumn(txtBlock3, 2);
            header.Children.Add(txtBlock3);

            return header;
        }

        private StackPanel CreateCustomerProductsPanel()
        {
            StackPanel productPanel = new StackPanel();
            foreach (var prod in _printReceiptVM.CustomerProducts)
            {
                Grid dataGrid = new Grid();
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(73, GridUnitType.Star) });
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Star) });

                TextBlock t1 = new TextBlock() { Text = prod.Quantity.ToString(), FontSize = 11.0 };
                Grid.SetColumn(t1, 0);
                dataGrid.Children.Add(t1);

                TextBlock t2 = new TextBlock() { Text = prod.ItemInfo, FontSize = 11.0 };
                Grid.SetColumn(t2, 1);
                dataGrid.Children.Add(t2);

                TextBlock t3 = new TextBlock() { Text = prod.Amount.ToString("C"), FontSize = 11.0, TextAlignment = TextAlignment.Right };
                Grid.SetColumn(t3, 2);
                dataGrid.Children.Add(t3);

                productPanel.Children.Add(dataGrid);
            }
            return productPanel;
        }
    }
}
