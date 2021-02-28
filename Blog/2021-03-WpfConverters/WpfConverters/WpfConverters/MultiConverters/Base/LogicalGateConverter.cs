using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace WpfConverters.MultiConverters.Base {
    public class LogicalGateConverter<T> : BaseMultiValueConverter {

        public delegate Boolean GateLogic(IEnumerable<Boolean> values);

        #region properties

        public GateLogic Logic { get; private set; }

        public LogicalGates Gate { set => Logic = GetLogicByGate(value); }

        public T True { get; set; }

        public T False { get; set; }

        #endregion

        #region ctors

        public LogicalGateConverter(LogicalGates gate, T @true, T @false) {
            Gate = gate;
            True = @true;
            False = @false;
        }

        public LogicalGateConverter(GateLogic logic, T @true, T @false) {
            Logic = logic;
            True = @true;
            False = @false;
        }

        #endregion

        #region methods

        public override Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture) {
            if(values.Any(value => value == null || !(value is Boolean))) { return DependencyProperty.UnsetValue; }

            return Logic(values.Cast<Boolean>()) ? True : False;
        }

        public override Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture) => null;

        private GateLogic GetLogicByGate(LogicalGates gate)
            => gate switch {
                LogicalGates.And => new GateLogic((values) => values.All(_ => _)),
                LogicalGates.Nand => new GateLogic((values) => values.Any(_ => !_)),
                LogicalGates.Or => new GateLogic((values) => values.Any(_ => _)),
                LogicalGates.Nor => new GateLogic((values) => values.All(_ => !_)),
                LogicalGates.Xor => new GateLogic((values) => values.Count(value => value) == 1),
                LogicalGates.Xnor => new GateLogic((values) => values.Count(value => value) != 1),
                _ => new GateLogic((_) => false),
            };

        #endregion

    }
}
