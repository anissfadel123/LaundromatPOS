using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace LaundroDesktopUI.CustomControls
{
    public class WdfCard : ContentControl
    {


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(WdfCard), new PropertyMetadata(null));



        public string CustomerName
        {
            get { return (string)GetValue(CustomerNameProperty); }
            set { SetValue(CustomerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerNameProperty =
            DependencyProperty.Register("CustomerName", typeof(string), typeof(WdfCard), new PropertyMetadata(""));




        public decimal Total
        {
            get { return (decimal)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(decimal), typeof(WdfCard), new PropertyMetadata(0M));


        public DateTime ReadyBy
        {
            get { return (DateTime)GetValue(ReadyByProperty); }
            set { SetValue(ReadyByProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReadyBy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadyByProperty =
            DependencyProperty.Register("ReadyBy", typeof(DateTime), typeof(WdfCard), new PropertyMetadata(null));




        public bool DisplayButton
        {
            get { return (bool)GetValue(DisplayButtonProperty); }
            set { SetValue(DisplayButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayButtonProperty =
            DependencyProperty.Register("DisplayButton", typeof(bool), typeof(WdfCard), new PropertyMetadata(true));



        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(WdfCard), new PropertyMetadata());



        public bool DisplayLeftArrow
        {
            get { return (bool)GetValue(DisplayLeftArrowProperty); }
            set { SetValue(DisplayLeftArrowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayLeftArrow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayLeftArrowProperty =
            DependencyProperty.Register("DisplayLeftArrow", typeof(bool), typeof(WdfCard), new PropertyMetadata(true));




        public Color ButtonColor
        {
            get { return (Color)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register("ButtonColor", typeof(Color), typeof(WdfCard), new PropertyMetadata());












    }
}
