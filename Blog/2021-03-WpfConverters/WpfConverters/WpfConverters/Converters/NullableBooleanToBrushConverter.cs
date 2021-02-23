using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullableBooleanToBrushConverter : NullableBooleanConverter<Brush> {

        public NullableBooleanToBrushConverter() : this(Brushes.Green, Brushes.Red, Brushes.Yellow) { }

        public NullableBooleanToBrushConverter(Brush @true, Brush @false, Brush @null) : base(@true, @false, @null) { }

    }
}
