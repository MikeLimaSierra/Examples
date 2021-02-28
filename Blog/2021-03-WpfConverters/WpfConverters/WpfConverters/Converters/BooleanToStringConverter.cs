using System;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean), typeof(String))]
    public class BooleanToStringConverter : BooleanConverter<String> {

        public BooleanToStringConverter() : this("true", "false") { }

        public BooleanToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
