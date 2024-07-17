using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CasioCalculatorModelDesigner.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        public string Format { get; set; } = "0.00";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double number)
                return DependencyProperty.UnsetValue;

            return number.ToString(Format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string numberString)
                return DependencyProperty.UnsetValue;
            if (!double.TryParse(numberString, out var number))
                    return DependencyProperty.UnsetValue;

            return number;
        }
    }
}
