using System;

using BB = System.Windows.Data.BindingBase;

namespace WpfConverters.Binding {
    public class MultiBinding : System.Windows.Data.MultiBinding {

        #region ctors

        public MultiBinding(params BB[] bindings) {
            Array.ForEach(bindings, _ => Bindings.Add(_));
        }

        public MultiBinding(BB b1) : this(new BB[] { b1 }) { }

        public MultiBinding(BB b1, BB b2) : this(new BB[] { b1, b2 }) { }

        public MultiBinding(BB b1, BB b2, BB b3) : this(new BB[] { b1, b2, b3 }) { }

        public MultiBinding(BB b1, BB b2, BB b3, BB b4) : this(new BB[] { b1, b2, b3, b4 }) { }

        public MultiBinding(BB b1, BB b2, BB b3, BB b4, BB b5) : this(new BB[] { b1, b2, b3, b4, b5 }) { }

        public MultiBinding(BB b1, BB b2, BB b3, BB b4, BB b5, BB b6) : this(new BB[] { b1, b2, b3, b4, b5, b6 }) { }

        public MultiBinding(BB b1, BB b2, BB b3, BB b4, BB b5, BB b6, BB b7) : this(new BB[] { b1, b2, b3, b4, b5, b6, b7 }) { }

        public MultiBinding(BB b1, BB b2, BB b3, BB b4, BB b5, BB b6, BB b7, BB b8) : this(new BB[] { b1, b2, b3, b4, b5, b6, b7, b8 }) { }

        #endregion

    }
}
