using System;
using System.Globalization;
using System.Windows;

namespace WpfConverters.Converters.Base {
    public class BooleanConverter<T> : BaseValueConverter {

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

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is Boolean boolean) {
                return boolean ? True : False;
            }

            return DependencyProperty.UnsetValue;
        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if(value != null && value is T t) {
                if(True.Equals(t)) { return true; }
                if(False.Equals(t)) { return false; }
            }

            return DependencyProperty.UnsetValue;
        }

        #endregion

    }
}
