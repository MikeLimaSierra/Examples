using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfConverters.Converters {
    public class Link : MarkupExtension {

        #region properties

        public IValueConverter Converter { get; set; }

        public Object Parameter { get; set; }

        public CultureInfo Culture { get; set; }

        #endregion

        #region methods

        public override Object ProvideValue(IServiceProvider serviceProvider) => this;

        #endregion

    }
}
