using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CasioCalculatorModelDesigner.Converters
{
    public class NormalizedToAbsoluteValueConverter : Freezable, IValueConverter
    {
        public double AbsoluteFullSize
        {
            get { return (double)GetValue(AbsoluteFullSizeProperty); }
            set { SetValue(AbsoluteFullSizeProperty, value); }
        }

        public static readonly DependencyProperty AbsoluteFullSizeProperty =
            DependencyProperty.Register("AbsoluteFullSize", typeof(double), typeof(NormalizedToAbsoluteValueConverter), new PropertyMetadata(1.0));



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double relativeSize)
                return DependencyProperty.UnsetValue;

            Debug.WriteLine($"Normalized 2 Absolute: {relativeSize * AbsoluteFullSize}");
            return relativeSize * AbsoluteFullSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double absoluteSize)
                return DependencyProperty.UnsetValue;

            return absoluteSize / AbsoluteFullSize;
        }

        protected override Freezable CreateInstanceCore() => new NormalizedToAbsoluteValueConverter();
    }
}
