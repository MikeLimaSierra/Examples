using System;
using System.Globalization;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NoOpConverter : BaseValueConverter {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => value;

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) => value;

    }
}
