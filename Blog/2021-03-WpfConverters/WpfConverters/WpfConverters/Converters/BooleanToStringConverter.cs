using System;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class BooleanToStringConverter : BooleanConverter<String> {

        public BooleanToStringConverter() : this("true", "false") { }

        public BooleanToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
