using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanOrToStringConverter : BooleanOrConverter<String> {

        public BooleanOrToStringConverter() : this("true", "false") { }

        public BooleanOrToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
