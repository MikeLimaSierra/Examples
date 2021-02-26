using System.Windows.Media;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class LogicalGateToBrushConverter : LogicalGateConverter<Brush> {

        public LogicalGateToBrushConverter() : this(LogicalGates.And) { }

        public LogicalGateToBrushConverter(LogicalGates gate) : this(gate, Brushes.Green, Brushes.Red) { }

        public LogicalGateToBrushConverter(GateLogic logic) : this(logic, Brushes.Green, Brushes.Red) { }

        public LogicalGateToBrushConverter(LogicalGates gate, Brush @true, Brush @false) : base(gate, @true, @false) { }

        public LogicalGateToBrushConverter(GateLogic logic, Brush @true, Brush @false) : base(logic, @true, @false) { }

    }
}
