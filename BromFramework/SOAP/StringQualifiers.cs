using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP {
	public partial class StringQualifiers {
		public StringQualifiers() {
		}
		public StringQualifiers(КвалификаторыСтроки квалификаторы) {
			this.Length = квалификаторы.Длина;
			this.AllowedLength = квалификаторы.ДопустимаяДлина.ToString();
		}

		public КвалификаторыСтроки GetValue() {
			ДопустимаяДлина допустимаяДлина = this.AllowedLength.Equals("Fixed", StringComparison.OrdinalIgnoreCase) || this.AllowedLength.Equals("Фиксированная", StringComparison.OrdinalIgnoreCase) ? ДопустимаяДлина.Фиксированная : ДопустимаяДлина.Переменная;
			return new КвалификаторыСтроки(this.Length, допустимаяДлина);
		}
	}
}
