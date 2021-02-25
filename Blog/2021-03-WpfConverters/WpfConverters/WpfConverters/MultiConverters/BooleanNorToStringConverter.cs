using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanNorToStringConverter : BooleanNorConverter<String> {

        public BooleanNorToStringConverter() : this("true", "false") { }

        public BooleanNorToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
