using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP {
	public partial class DateQualifiers {
		public DateQualifiers() {
		}
		public DateQualifiers(КвалификаторыДаты квалификаторы) {
			this.DateFractions = квалификаторы.ЧастиДаты.ToString();
		}

		public КвалификаторыДаты GetValue() {
			ЧастиДаты частиДаты = ЧастиДаты.ДатаВремя;
			if (this.DateFractions.Equals("Date", StringComparison.OrdinalIgnoreCase) || this.DateFractions.Equals("Дата", StringComparison.OrdinalIgnoreCase)) {
				частиДаты = ЧастиДаты.Дата;
			}else if (this.DateFractions.Equals("Time", StringComparison.OrdinalIgnoreCase) || this.DateFractions.Equals("Время", StringComparison.OrdinalIgnoreCase)) {
				частиДаты = ЧастиДаты.Время;
			}
			return new КвалификаторыДаты(частиДаты);
		}
	}
}
