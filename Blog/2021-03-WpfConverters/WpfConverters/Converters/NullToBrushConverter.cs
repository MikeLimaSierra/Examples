using System;
using System.Windows.Data;
using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Object), typeof(Brush))]
    public class NullToBrushConverter : NullConverter<Brush> {

        public NullToBrushConverter() : this(Brushes.Red, Brushes.Green) { }

        public NullToBrushConverter(Brush @null, Brush notNull) : base(@null, notNull) { }

    }
}
