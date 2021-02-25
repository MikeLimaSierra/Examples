using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class BooleanNorToBrushConverter : BooleanNorConverter<Brush> {

        public BooleanNorToBrushConverter() : this(Brushes.Green, Brushes.Red) { }

        public BooleanNorToBrushConverter(Brush @true, Brush @false) : base(@true, @false) { }

    }
}
