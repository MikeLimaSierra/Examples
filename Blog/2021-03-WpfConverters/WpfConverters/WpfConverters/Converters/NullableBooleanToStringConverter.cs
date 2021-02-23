using System;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullableBooleanToStringConverter : NullableBooleanConverter<String> {

        public NullableBooleanToStringConverter() : this("true", "false", "null") { }

        public NullableBooleanToStringConverter(String @true, String @false, String @null) : base(@true, @false, @null) { }

    }
}
