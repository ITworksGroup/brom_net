namespace ITworks.Brom.SOAP { 
    public partial class ValueBoolean {
		public ValueBoolean() {

		}
		public ValueBoolean(bool value) {
			this.Value = value;
		}
		public ValueBoolean(object value) : this((bool)value) { }

		public override object GetValue(БромКлиент client = null) {
			return this.Value;
		}

		public static implicit operator ValueBoolean(bool value) {
			return new ValueBoolean(value);
		}
		public static explicit operator bool(ValueBoolean value) {
			return value.Value;
		}
	}
}
