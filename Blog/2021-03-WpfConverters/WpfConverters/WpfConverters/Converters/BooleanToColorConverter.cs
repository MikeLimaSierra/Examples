using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class BooleanToColorConverter : BooleanConverter<Color> {

        public BooleanToColorConverter() : this(Colors.Green, Colors.Red) { }

        public BooleanToColorConverter(Color @true, Color @false) : base(@true, @false) { }

    }
}
