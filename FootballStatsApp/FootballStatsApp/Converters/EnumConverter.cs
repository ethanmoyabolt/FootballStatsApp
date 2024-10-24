using System;
using System.Globalization;
using Xamarin.Forms;

namespace FootballStatsApp.Converters
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is Enum)
            {
                return ((Enum)value).ToString();
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is string && targetType.IsEnum)
            {
                return Enum.Parse(targetType, (string)value);
            }

            return null;

        }
    }
}
