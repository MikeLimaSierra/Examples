using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanXnorToStringConverter : BooleanXnorConverter<String> {

        public BooleanXnorToStringConverter() : this("true", "false") { }

        public BooleanXnorToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
