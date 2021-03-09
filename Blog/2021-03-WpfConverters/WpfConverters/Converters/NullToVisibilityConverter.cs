using System;
using System.Windows;
using System.Windows.Data;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {

    [ValueConversion(typeof(Object), typeof(Visibility))]
    public class NullToVisibilityConverter : NullConverter<Visibility> {

        public NullToVisibilityConverter() : this(Visibility.Collapsed, Visibility.Visible) { }

        public NullToVisibilityConverter(Visibility @null, Visibility notNull) : base(@null, notNull) { }

    }
}
