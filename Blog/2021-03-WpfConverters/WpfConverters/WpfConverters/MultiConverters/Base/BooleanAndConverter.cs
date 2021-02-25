using System;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace WpfConverters.MultiConverters.Base {
    public class BooleanAndConverter<T> : BaseMultiValueConverter {

        #region properties

        public T True { get; set; }

        public T False { get; set; }

        #endregion

        #region ctors

        public BooleanAndConverter(T @true, T @false) {
            True = @true;
            False = @false;
        }

        #endregion

        #region methods

        public override Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture) {
            if(values.Any(value => value == null || !(value is Boolean))) { return DependencyProperty.UnsetValue; }

            return values.Cast<Boolean>().All(value => value) ? True : False;
        }

        public override Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture) => null;

        #endregion

    }
}
