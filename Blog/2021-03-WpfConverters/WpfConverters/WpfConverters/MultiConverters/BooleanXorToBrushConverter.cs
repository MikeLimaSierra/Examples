using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanXorToBrushConverter : BooleanXorConverter<Brush> {

        public BooleanXorToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanXorToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
