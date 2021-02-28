using System;
using System.Windows.Data;
using System.Windows.Media;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean?), typeof(Color))]
    public class NullableBooleanToColorConverter : NullableBooleanConverter<Color> {

        public NullableBooleanToColorConverter() : this(Colors.Green, Colors.Red, Colors.Yellow) { }

        public NullableBooleanToColorConverter(Color @true, Color @false, Color @null) : base(@true, @false, @null) { }

    }
}
