using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P06Shop.Shared.Converters
{
    public class DurationToDisplayConverter
    {
        public static object Convert(object value)
        {
            if (value is int || value is long) {
                TimeSpan timeSpan = TimeSpan.FromSeconds((long)value);
                return $"{timeSpan.Minutes}m {timeSpan.Seconds}s";
            }
                

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }
    }
}
