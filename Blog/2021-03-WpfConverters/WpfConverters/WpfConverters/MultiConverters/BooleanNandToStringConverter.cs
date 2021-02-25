using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanNandToStringConverter : BooleanNandConverter<String> {

        public BooleanNandToStringConverter() : this("true", "false") { }

        public BooleanNandToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
