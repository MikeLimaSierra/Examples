using System.Windows;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class BooleanToVisibilityConverter : BooleanConverter<Visibility> {

        public BooleanToVisibilityConverter() : this(Visibility.Visible, Visibility.Collapsed) { }

        public BooleanToVisibilityConverter(Visibility @true, Visibility @false) : base(@true, @false) { }

    }
}
