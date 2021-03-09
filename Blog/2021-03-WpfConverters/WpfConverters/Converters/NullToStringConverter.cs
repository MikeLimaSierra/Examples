using System;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Object), typeof(String))]
    public class NullToStringConverter : NullConverter<String> {

        public NullToStringConverter() : this("null", "not null") { }

        public NullToStringConverter(String @null, String notNull) : base(@null, notNull) { }

    }
}
