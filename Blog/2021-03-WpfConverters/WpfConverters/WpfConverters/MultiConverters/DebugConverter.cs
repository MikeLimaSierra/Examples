using System;
using System.Diagnostics;
using System.Globalization;

using WpfConverters.Converters.Base;

namespace WpfConverters.MultiConverters {
    class DebugConverter : BaseValueConverter {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            Debugger.Break();
            return value;
        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            Debugger.Break();
            return value;
        }

    }
}
