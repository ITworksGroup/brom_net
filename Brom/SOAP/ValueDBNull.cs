using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueDBNull {
		public ValueDBNull() {	
		}

		public override object GetValue(БромКлиент client = null) {
			return DBNull.Value;
		}

		public static implicit operator ValueDBNull(DBNull value) {
			return new ValueDBNull();
		}
		public static explicit operator DBNull(ValueDBNull value) {
			return DBNull.Value;
		}
	}
}
