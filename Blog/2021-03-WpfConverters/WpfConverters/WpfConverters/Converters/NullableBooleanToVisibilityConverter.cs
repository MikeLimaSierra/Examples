using System.Windows;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullableBooleanToVisibilityConverter : NullableBooleanConverter<Visibility> {

        public NullableBooleanToVisibilityConverter() : this(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden) { }

        public NullableBooleanToVisibilityConverter(Visibility @true, Visibility @false, Visibility @null) : base(@true, @false, @null) { }

    }
}
