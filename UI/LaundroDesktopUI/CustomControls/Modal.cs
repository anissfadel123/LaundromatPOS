using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LaundroDesktopUI.CustomControls
{
    public class Modal : ContentControl
    {


        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }      
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Modal), new PropertyMetadata(false));



        public double ModalHeight
        {
            get { return (double)GetValue(ModalHeightProperty); }
            set { SetValue(ModalHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ModalHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModalHeightProperty =
            DependencyProperty.Register("ModalHeight", typeof(double), typeof(Modal), new PropertyMetadata(200.0));



        public double ModalWidth
        {
            get { return (double)GetValue(ModalWidthProperty); }
            set { SetValue(ModalWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ModalWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModalWidthProperty =
            DependencyProperty.Register("ModalWidth", typeof(double), typeof(Modal), new PropertyMetadata(200.0));





    }
}
