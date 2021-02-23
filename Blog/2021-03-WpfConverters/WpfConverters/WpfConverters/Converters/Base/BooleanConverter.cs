using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfConverters.Converters.Base {
    public class BooleanConverter<T> : IValueConverter {

        #region properties

        public T True { get; set; }

        public T False { get; set; }

        #endregion

        #region ctors

        public BooleanConverter(T @true, T @false) {
            True = @true;
            False = @false;
        }

        #endregion

        #region methods

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is Boolean boolean) {
                return boolean ? True : False;
            }

            return DependencyProperty.UnsetValue;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is T t) {
                if(True.Equals(t)) { return true; }
                if(False.Equals(t)) { return false; }
            }

            return DependencyProperty.UnsetValue;
        }

        #endregion

    }
}
