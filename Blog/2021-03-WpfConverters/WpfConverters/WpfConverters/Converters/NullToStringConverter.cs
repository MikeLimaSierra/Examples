using System;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullToStringConverter : NullConverter<String> {

        public NullToStringConverter() : this("null", "not null") { }

        public NullToStringConverter(String @null, String notNull) : base(@null, notNull) { }

    }
}
