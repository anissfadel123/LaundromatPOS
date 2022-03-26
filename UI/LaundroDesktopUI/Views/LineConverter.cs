using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LaundroDesktopUI.Views
{
    public class LineConverter : IValueConverter
    {
        public double Decrease { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double a = 0;
            if (value != null)
            {
                try
                {
                    a = System.Convert.ToDouble(value);
                }
                catch
                {
                    a = 0;
                }
            }
            return a - Decrease;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double a = 0;
            if (value != null)
            {
                try
                {
                    a = System.Convert.ToDouble(value);
                }
                catch
                {
                    a = 0;
                }
            }
            return a + Decrease;
        }
    
    }
}
