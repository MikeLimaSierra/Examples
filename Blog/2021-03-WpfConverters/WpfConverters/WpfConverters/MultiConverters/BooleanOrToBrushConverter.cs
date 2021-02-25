using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanOrToBrushConverter : BooleanOrConverter<Brush> {

        public BooleanOrToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanOrToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
