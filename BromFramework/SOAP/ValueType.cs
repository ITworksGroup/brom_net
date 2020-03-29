using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueType {
		public ValueType() {
		}

		public ValueType(Тип value) {
			this.Value = value.XmlИмя;
			this.Namespace = value.XmlПространствоИмен;
			if (this.Namespace.Equals("http://www.w3.org/2001/XMLSchema", StringComparison.OrdinalIgnoreCase)) {
				this.Namespace = Тип.XMLПространствоИменXmlSchema;
			}
			else if (this.Namespace.Equals("http://v8.1c.ru/data", StringComparison.OrdinalIgnoreCase)) {
				this.Namespace = Тип.XMLПространствоИмен1C;
			}
		}
		public ValueType(object value) : this((Тип)value) { }

		public override object GetValue(БромКлиент client = null) {
			string ns = this.Namespace;
			if (ns.Equals(Тип.XMLПространствоИменXmlSchema, StringComparison.OrdinalIgnoreCase)) {
				ns = "http://www.w3.org/2001/XMLSchema";
			}
			else if (ns.Equals(Тип.XMLПространствоИмен1C, StringComparison.OrdinalIgnoreCase)) {
				ns = "http://v8.1c.ru/data";
			}
			return new Тип(this.Value, ns);
		}

		public static implicit operator ValueType(Тип value) {
			return new ValueType(value);
		}
		public static explicit operator Тип(ValueType value) {
			return (Тип)value.GetValue();
		}
	}
}
