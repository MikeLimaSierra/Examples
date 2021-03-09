using System;
using System.Globalization;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Object), typeof(Object))]
    public class NoOpConverter : BaseValueConverter {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => value;

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) => value;

    }
}
