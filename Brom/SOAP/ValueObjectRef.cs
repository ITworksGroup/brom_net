using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP {
	public partial class ValueObjectRef {
		public ValueObjectRef() {
		}
		public ValueObjectRef(ОбъектСсылка value) {
			this.Type = value != null ? value.ПолноеИмяТипа() : throw new System.ArgumentNullException("value");
			this.Value = value.УникальныйИдентификатор().ToString();
		}
		public ValueObjectRef(Ссылка value) : this((ОбъектСсылка)value) {
		}
		public ValueObjectRef(object value) : this((ОбъектСсылка)value) {
		}

		public override object GetValue(БромКлиент client = null) {
			ОбъектСсылка reference = client != null ? client.Контекст().ПолучитьОбъектСсылку(this.Type, new Guid(this.Value)) : throw new System.ArgumentNullException("client");
			if (this.Presentation != null) {
				client.Контекст().УстановитьПредставлениеОбъекта(reference, this.Presentation);
			}
			if (this.Property != null) {
				client.Контекст().УстановитьЗначенияИзСвойствSOAP(reference, this.Property);
			}
			return reference;
		}

		public static implicit operator ValueObjectRef(ОбъектСсылка value) {
			return new ValueObjectRef(value);
		}
		public static implicit operator ValueObjectRef(Ссылка value) {
			return new ValueObjectRef(value);

		}
	}
}
