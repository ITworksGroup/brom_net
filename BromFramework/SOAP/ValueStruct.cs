using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueStruct {
		public ValueStruct() {
			
		}
		public ValueStruct(Структура value) {
			if (value == null) {
				throw new System.ArgumentNullException("value");
			}

			this.Property = new ValueBase[value.Count];
			int i = 0;
			foreach (var keyValue in value) {
				ValueBase property = ValueBase.From(keyValue.Value);
				property.Name = keyValue.Key;
				this.Property[i] = property;
				i++;
			}
		}
		public ValueStruct(object value) : this((Структура)value) { }

		public override object GetValue(БромКлиент client = null) {
			return this.ToStruct(client);
		}

		public static implicit operator ValueStruct(Структура value) {
			return new ValueStruct(value);
		}
	}
}
