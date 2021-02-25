using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanNandToBrushConverter : BooleanNandConverter<Brush> {

        public BooleanNandToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanNandToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
