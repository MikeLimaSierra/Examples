using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class LogicalGateToBooleanConverter : LogicalGateConverter<Boolean> {

        public LogicalGateToBooleanConverter() : this(LogicalGates.And) { }

        public LogicalGateToBooleanConverter(LogicalGates gate) : this(gate, true, false) { }

        public LogicalGateToBooleanConverter(GateLogic logic) : this(logic, true, false) { }

        public LogicalGateToBooleanConverter(LogicalGates gate, Boolean @true, Boolean @false) : base(gate, @true, @false) { }

        public LogicalGateToBooleanConverter(GateLogic logic, Boolean @true, Boolean @false) : base(logic, @true, @false) { }

    }
}
