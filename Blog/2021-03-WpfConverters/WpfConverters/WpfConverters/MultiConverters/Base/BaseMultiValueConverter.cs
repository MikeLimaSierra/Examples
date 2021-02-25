using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfConverters.MultiConverters.Base {
    public abstract class BaseMultiValueConverter : MarkupExtension, IMultiValueConverter {

        public abstract Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture);

        public abstract Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture);

        public override Object ProvideValue(IServiceProvider serviceProvider) => this;

    }
}
