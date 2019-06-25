using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueBoundary {
		public ValueBoundary() {
		}
		public ValueBoundary(System.ValueType value, string type) {
			this.Value = ValueBase.From(value);
			this.Type = type;
		}
		public ValueBoundary(Граница baundary) : this(baundary.Значение, baundary.ВидГраницы.ToString()) { }
		public ValueBoundary(object value) : this((Граница)value) { }

		public override object GetValue(БромКлиент client = null) {
			object curValue = this.Value.GetValue(client);
			ВидГраницы boundaryType = Enum.Parse<ВидГраницы>(this.Type);

			if (curValue.GetType() == typeof(МоментВремени)) {
				return new Граница((МоментВремени)curValue, boundaryType);
			}
			else if (curValue.GetType() == typeof(DateTime)) {
				return new Граница((DateTime)curValue, boundaryType);
			}

			throw new Exception("Wrong data type for \"Value\" field. Current type is: " + curValue.GetType().ToString() + ".");
		}

		public static implicit operator ValueBoundary(Граница value) {
			return new ValueBoundary(value);
		}
	}
}
