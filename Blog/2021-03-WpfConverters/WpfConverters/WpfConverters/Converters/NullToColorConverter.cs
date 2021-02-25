using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullToColorConverter : NullConverter<Color> {

        public NullToColorConverter() : this(Colors.Red, Colors.Green) { }

        public NullToColorConverter(Color @null, Color notNull) : base(@null, notNull) { }

    }
}
