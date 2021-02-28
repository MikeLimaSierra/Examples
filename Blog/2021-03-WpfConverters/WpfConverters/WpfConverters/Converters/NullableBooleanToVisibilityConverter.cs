using System;
using System.Windows;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean?), typeof(Visibility))]
    public class NullableBooleanToVisibilityConverter : NullableBooleanConverter<Visibility> {

        public NullableBooleanToVisibilityConverter() : this(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden) { }

        public NullableBooleanToVisibilityConverter(Visibility @true, Visibility @false, Visibility @null) : base(@true, @false, @null) { }

    }
}
