using System;
using System.Windows;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Boolean), typeof(Visibility))]
    public class BooleanToVisibilityConverter : BooleanConverter<Visibility> {

        public BooleanToVisibilityConverter() : this(Visibility.Visible, Visibility.Collapsed) { }

        public BooleanToVisibilityConverter(Visibility @true, Visibility @false) : base(@true, @false) { }

    }
}
