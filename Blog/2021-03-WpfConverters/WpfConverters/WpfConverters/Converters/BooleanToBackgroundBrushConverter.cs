using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfConverters.Converters {
    public class BooleanToBackgroundBrushConverter : IValueConverter {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is Boolean boolean) {
                return boolean ? Brushes.Magenta : Brushes.LightGray;
            }

            return DependencyProperty.UnsetValue;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;

    }
}
