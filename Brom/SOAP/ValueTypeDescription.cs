using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueTypeDescription {
		public ValueTypeDescription() {
		}
		public ValueTypeDescription(ОписаниеТипов value) {
			this.Item = new ValueType[value.Count];
			for (int i = 0; i < value.Count; i++) {
				this.Item[i] = new ValueType(value[i]);
			}

			this.NumberQualifiers = value.КвалификаторыЧисла != null ? new NumberQualifiers(value.КвалификаторыЧисла) : null;
			this.StringQualifiers = value.КвалификаторыСтроки != null ? new StringQualifiers(value.КвалификаторыСтроки) : null;
			this.DateQualifiers = value.КвалификаторыДаты != null ? new DateQualifiers(value.КвалификаторыДаты) : null;
			this.BinaryDataQualifiers = value.КвалификаторыДвоичныхДанных != null ? new BinaryDataQualifiers(value.КвалификаторыДвоичныхДанных) : null;
		}
		public ValueTypeDescription(object value) : this((ОписаниеТипов)value) { }

		public override object GetValue(БромКлиент client = null) {
			return new ОписаниеТипов(
				Array.ConvertAll(this.Item, new Converter<ValueType, Тип>(val => (Тип)val.GetValue(client))),
				this.NumberQualifiers != null ? this.NumberQualifiers.GetValue() : null,
				this.StringQualifiers != null ? this.StringQualifiers.GetValue() : null,
				this.DateQualifiers != null ? this.DateQualifiers.GetValue() : null,
				this.BinaryDataQualifiers != null ? this.BinaryDataQualifiers.GetValue() : null
			);
		}

		public static implicit operator ValueTypeDescription(ОписаниеТипов value) {
			return new ValueTypeDescription(value);
		}
		public static explicit operator ОписаниеТипов(ValueTypeDescription value) {
			return (ОписаниеТипов)value.GetValue();
		}
	}
}
