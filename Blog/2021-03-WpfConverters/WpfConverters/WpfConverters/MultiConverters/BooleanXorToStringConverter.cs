using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanXorToStringConverter : BooleanXorConverter<String> {

        public BooleanXorToStringConverter() : this("true", "false") { }

        public BooleanXorToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
