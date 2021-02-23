using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class BooleanToBrushConverter : BooleanConverter<Brush> {

        public BooleanToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
