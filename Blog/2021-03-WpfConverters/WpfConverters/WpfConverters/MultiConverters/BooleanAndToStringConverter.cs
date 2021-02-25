using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanAndToStringConverter : BooleanAndConverter<String> {

        public BooleanAndToStringConverter() : this("true", "false") { }

        public BooleanAndToStringConverter(String @true, String @false) : base(@true, @false) { }

    }
}
