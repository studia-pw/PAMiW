using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace P04WeatherForecastAPI.Client.Converters
{
    internal class PopulationToDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int || value is long) {
                StringBuilder stringBuilder = new StringBuilder(value.ToString());
                
                int index1 = stringBuilder.Length - 3; // div by 1000
                while (index1 > 0) {
                    stringBuilder.Insert(index1, " ");
                    index1 -= 3;
                }

                return stringBuilder.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string population = value as string;
            return population != null ? population.Replace(" ", "") : value;
        }
    }
}
