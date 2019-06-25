namespace ITworks.Brom.SOAP { 
    public partial class ValueString {
		public ValueString() {
		}
		public ValueString(string value) {
			this.Value = value;
		}
		public ValueString(object value) : this((string)value) { }

		public override object GetValue(БромКлиент client = null) {
			return this.Value;
		}

		public static implicit operator ValueString(string value) {
			return new ValueString(value);
		}
		public static explicit operator string(ValueString value) {
			return value.Value;
		}
	}
}
