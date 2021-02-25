using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanXnorToBrushConverter : BooleanXnorConverter<Brush> {

        public BooleanXnorToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanXnorToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
