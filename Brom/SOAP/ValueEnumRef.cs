using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueEnumRef {
		public ValueEnumRef() {
			
		}
		public ValueEnumRef(ПеречислениеСсылка value) {
			this.Type = value != null ? value.ПолноеИмяТипа() : throw new System.ArgumentNullException("value");
			this.Value = value.Имя;
		}
		public ValueEnumRef(Ссылка value):this((ПеречислениеСсылка)value) {
		}
		public ValueEnumRef(object value) : this((ПеречислениеСсылка)value) {
		}

		public override object GetValue(БромКлиент client = null) {
			return client != null ? client.Контекст().ПолучитьПеречислениеСсылку(this.Type, this.Value) : throw new System.ArgumentNullException("client");
		}

		public static implicit operator ValueEnumRef(ПеречислениеСсылка value) {
			return new ValueEnumRef(value);
		}
		public static implicit operator ValueEnumRef(Ссылка value) {
			return new ValueEnumRef(value);
		}
	}
}
