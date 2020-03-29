using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueStorage {
		public ValueStorage() {
		}
		public ValueStorage(ХранилищеЗначения value) {
			this.Data = ValueBase.From(value.Получить());
		}
		public ValueStorage(object value) : this((ХранилищеЗначения)value) { }

		public override object GetValue(БромКлиент client = null) {
			return new ХранилищеЗначения(this.Data.GetValue(client));
		}

		public static implicit operator ValueStorage(ХранилищеЗначения value) {
			return new ValueStorage(value);
		}
	}
}
