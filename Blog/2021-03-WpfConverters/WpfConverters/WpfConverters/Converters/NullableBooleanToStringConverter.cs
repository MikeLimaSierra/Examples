using System;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean?), typeof(String))]
    public class NullableBooleanToStringConverter : NullableBooleanConverter<String> {

        public NullableBooleanToStringConverter() : this("true", "false", "null") { }

        public NullableBooleanToStringConverter(String @true, String @false, String @null) : base(@true, @false, @null) { }

    }
}
