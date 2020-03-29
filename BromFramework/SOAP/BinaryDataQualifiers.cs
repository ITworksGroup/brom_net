using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP {
	public partial class BinaryDataQualifiers {
		public BinaryDataQualifiers() {
		}
		public BinaryDataQualifiers(КвалификаторыДвоичныхДанных квалификаторы) {
			this.Length = квалификаторы.Длина;
			this.AllowedLength = квалификаторы.ДопустимаяДлина.ToString();
		}

		public КвалификаторыДвоичныхДанных GetValue() {
			ДопустимаяДлина допустимаяДлина = this.AllowedLength.Equals("Fixed", StringComparison.OrdinalIgnoreCase) || this.AllowedLength.Equals("Фиксированная", StringComparison.OrdinalIgnoreCase) ? ДопустимаяДлина.Фиксированная : ДопустимаяДлина.Переменная;
			return new КвалификаторыДвоичныхДанных(this.Length, допустимаяДлина);
		}
	}
}
