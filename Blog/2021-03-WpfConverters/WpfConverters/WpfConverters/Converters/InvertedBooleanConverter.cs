using System;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean), typeof(Boolean))]
    public class InvertedBooleanConverter : BooleanConverter<Boolean> {

        public InvertedBooleanConverter() : base(false, true) { }

    }
}
