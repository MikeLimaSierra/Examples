using System.Windows;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public class NullToVisibilityConverter : NullConverter<Visibility> {

        public NullToVisibilityConverter() : this(Visibility.Collapsed, Visibility.Visible) { }

        public NullToVisibilityConverter(Visibility @null, Visibility notNull) : base(@null, notNull) { }

    }
}
