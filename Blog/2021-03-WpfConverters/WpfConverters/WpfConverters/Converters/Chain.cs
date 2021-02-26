using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

using WpfConverters.Converters.Base;

namespace WpfConverters.Converters {
    public partial class Chain : BaseValueConverter {

        #region properties

        public Collection<Link> Links { get; } = new Collection<Link>();

        #endregion

        #region ctors

        public Chain(params Link[] links) {
            Array.ForEach(links, _ => Links.Add(_));
        }

        public Chain(Link l1) : this(new Link[] { l1 }) { }

        public Chain(Link l1, Link l2) : this(new Link[] { l1, l2 }) { }

        public Chain(Link l1, Link l2, Link l3) : this(new Link[] { l1, l2, l3 }) { }

        public Chain(Link l1, Link l2, Link l3, Link l4) : this(new Link[] { l1, l2, l3, l4 }) { }

        public Chain(Link l1, Link l2, Link l3, Link l4, Link l5) : this(new Link[] { l1, l2, l3, l4, l5 }) { }

        public Chain(Link l1, Link l2, Link l3, Link l4, Link l5, Link l6) : this(new Link[] { l1, l2, l3, l4, l5, l6 }) { }

        public Chain(Link l1, Link l2, Link l3, Link l4, Link l5, Link l6, Link l7) : this(new Link[] { l1, l2, l3, l4, l5, l6, l7 }) { }

        public Chain(Link l1, Link l2, Link l3, Link l4, Link l5, Link l6, Link l7, Link l8) : this(new Link[] { l1, l2, l3, l4, l5, l6, l7, l8 }) { }

        #endregion

        #region methods

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            Object returnObject = value;

            foreach(Link link in Links) {
                returnObject = link.Converter.Convert(returnObject, targetType, link.Parameter, link.Culture);
            }

            return returnObject;
        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            Object returnObject = value;

            foreach(Link link in Links.Reverse()) {
                returnObject = link.Converter.ConvertBack(returnObject, targetType, link.Parameter, link.Culture);
            }

            return returnObject;
        }

        #endregion

    }
}
