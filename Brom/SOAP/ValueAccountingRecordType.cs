using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueAccountingRecordType {
		public ValueAccountingRecordType() {
			
		}
		public ValueAccountingRecordType(ВидДвиженияБухгалтерии значение) {
			this.Value = значение.ToString();
		}
		public ValueAccountingRecordType(object value) : this((ВидДвиженияБухгалтерии)value) { }

		public override object GetValue(БромКлиент client = null) {
			switch (this.Value) {
				case "Debit":	return ВидДвиженияБухгалтерии.Дебет;
				case "Credit":	return ВидДвиженияБухгалтерии.Кредит;

				case "Дебет":	return ВидДвиженияБухгалтерии.Дебет;
				case "Кредит":	return ВидДвиженияБухгалтерии.Кредит;
			}

			throw new Exception("Недопустимое значение поля \"Value\".");
		}
	}
}
