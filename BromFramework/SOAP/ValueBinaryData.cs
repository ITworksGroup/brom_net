using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueBinaryData {
		public ValueBinaryData() {
		}
		public ValueBinaryData(ДвоичныеДанные value) {
			this.Value = value.Данные;
		}
		public ValueBinaryData(object value) : this((ДвоичныеДанные)value) { }

		public override object GetValue(БромКлиент client = null) {
			return new ДвоичныеДанные(this.Value ?? new byte[0]);
		}

		public static implicit operator ValueBinaryData(ДвоичныеДанные value) {
			return new ValueBinaryData(value);
		}
		public static explicit operator byte[] (ValueBinaryData value) {
			return value.Value;
		}
	}
}
