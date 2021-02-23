using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfConverters.Converters {
    public class BooleanToStringConverter : IValueConverter {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is Boolean boolean) {
                return boolean ? "Pressed." : "Not pressed.";
            }
            return DependencyProperty.UnsetValue;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;

    }
}
