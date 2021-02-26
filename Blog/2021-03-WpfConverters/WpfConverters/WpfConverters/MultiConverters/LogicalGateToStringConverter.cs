using System;

using WpfConverters.MultiConverters.Base;

namespace WpfConverters.MultiConverters {
    public class LogicalGateToStringConverter : LogicalGateConverter<String> {

        public LogicalGateToStringConverter() : this(LogicalGates.And) { }

        public LogicalGateToStringConverter(LogicalGates gate) : this(gate, "true", "false") { }

        public LogicalGateToStringConverter(GateLogic logic) : this(logic, "true", "false") { }

        public LogicalGateToStringConverter(LogicalGates gate, String @true, String @false) : base(gate, @true, @false) { }

        public LogicalGateToStringConverter(GateLogic logic, String @true, String @false) : base(logic, @true, @false) { }

    }
}
