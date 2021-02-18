using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XAMARIN_MVVM.Models
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val=value.ToString();
            if (val.ToString()=="") { return ""; }
            double d = 0;
            double.TryParse(val, out d);
            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Back");
            return value;
        }
    }
}
