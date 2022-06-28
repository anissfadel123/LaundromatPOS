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
using System.Printing;

namespace LaundroDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for PrintReceiptView.xaml
    /// </summary>
    public partial class PrintReceiptView : UserControl
    {
        public PrintReceiptView()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    PrintDialog printDlg = new PrintDialog();
       
            
        //    //FlowDocument doc = CreateFlowDocument();
        //    FlowDocument doc = new FlowDocument();
        //    doc.PageWidth = printDlg.PrintableAreaWidth;

        //    receiptBorder.Child = null;
        //    doc.Blocks.Add(new BlockUIContainer(PrintDoc));
        //    doc.Name="FlowDoc";

        //    IDocumentPaginatorSource idpSource = doc;
        //    printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        //}

        //private FlowDocument CreateFlowDocument()
        //{
        //    // Create a FlowDocument  
        //    FlowDocument doc = new FlowDocument();
            
        //    doc.PagePadding = new Thickness(0, 0, 0, 0);
            
        //    //doc.PageWidth = 300;
        //    // Create a Section  
        //    Section sec = new Section();
        //    // Create first Paragraph  
        //    Paragraph p1 = new Paragraph(), p2 = new Paragraph();
        //    p1.TextAlignment = TextAlignment.Center;
        //    p1.FontSize = 11;

        //    p2.FontSize = 11;

            
        //    p1.FontFamily = new FontFamily("Fonts/#Poppins");
        //    p1.Inlines.Add(new Run("Welcome to\nSix Bro Laundromat\n8115 Flatlands Avenue\nBrooklyn, NY 11235\n(929)123-4567\n"));
        //    Bold bold = new Bold(new Run("Customer: John\nCustomer ID: 1\nDate: June 22, 2022, 5:50:03 PM\nInvoice#: 1044"));
        //    p2.Inlines.Add(bold);
        
            
        //    // Create and add a new Bold, Italic and Underline  
        //    //Bold bld = new Bold();
        //    //bld.Inlines.Add(new Run("First Paragraph"));
        //    //Italic italicBld = new Italic();
        //    //italicBld.Inlines.Add(bld);
        //    //Underline underlineItalicBld = new Underline();
        //    //underlineItalicBld.FontSize = 50;
        //    //underlineItalicBld.Inlines.Add(italicBld);
        //    //// Add Bold, Italic, Underline to Paragraph  
        //    //p1.Inlines.Add(underlineItalicBld);

            

        //    // Add Paragraph to Section  
        //    sec.Blocks.Add(p1);
        //    sec.Blocks.Add(p2);
        //    // Add Section to FlowDocument  
        //    doc.Blocks.Add(sec);
        //    return doc;
        //}
    }
}
