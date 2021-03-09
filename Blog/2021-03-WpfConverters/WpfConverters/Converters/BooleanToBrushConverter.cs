using System;
using System.Windows.Data;
using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean), typeof(Brush))]
    public class BooleanToBrushConverter : BooleanConverter<Brush> {

        public BooleanToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
