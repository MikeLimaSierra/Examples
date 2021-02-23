using System;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class InvertedBooleanConverter : BooleanConverter<Boolean> {

        public InvertedBooleanConverter() : base(false, true) { }

    }
}
