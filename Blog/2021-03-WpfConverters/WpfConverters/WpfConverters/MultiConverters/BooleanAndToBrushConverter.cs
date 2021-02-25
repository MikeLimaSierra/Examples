using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanAndToBrushConverter : BooleanAndConverter<Brush> {

        public BooleanAndToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanAndToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
