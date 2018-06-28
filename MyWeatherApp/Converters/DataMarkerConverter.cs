using System;
using MyWeatherApp.Classes;
using Xamarin.Forms;

namespace MyWeatherApp.Converters
{
	public class DataMarkerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var dataModel = value as Temperature;

                if ((dataModel.IsLastValue))
                {
					return dataModel.Temp;
                }
            }

            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
