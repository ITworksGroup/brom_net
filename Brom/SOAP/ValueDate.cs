using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueDate {
		public ValueDate() {
		}

		public ValueDate(DateTime value) {
			this.Value = value;
		}
		public ValueDate(object value) : this((DateTime)value) { }

		public override object GetValue(БромКлиент client = null) {
			return this.Value;
		}

		public static implicit operator ValueDate(DateTime value) {
			return new ValueDate(value);
		}
		public static explicit operator DateTime(ValueDate value) {
			return value.Value;
		}
	}
}
