using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueGuid {
		public ValueGuid() {
		}
		public ValueGuid(Guid value) {
			this.Value = value.ToString();
		}
		public ValueGuid(object value) : this((Guid)value) { }

		public override object GetValue(БромКлиент client = null) {
			return new Guid(this.Value);
		}

		public static implicit operator ValueGuid(string value) {
			return new ValueGuid(new Guid(value));
		}
		public static implicit operator ValueGuid(Guid value) {
			return new ValueGuid(value);
		}
		public static explicit operator Guid(ValueGuid value) {
			return new Guid(value.Value);
		}
	}
}
