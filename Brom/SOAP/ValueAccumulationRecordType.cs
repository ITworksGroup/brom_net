using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueAccumulationRecordType {
		public ValueAccumulationRecordType() {	
		}
		public ValueAccumulationRecordType(ВидДвиженияНакопления значение) {
			this.Value = значение.ToString();
		}
		public ValueAccumulationRecordType(object value) : this((ВидДвиженияНакопления)value) { }

		public override object GetValue(БромКлиент client = null) {
			switch (this.Value) {
				case "Receipt":	return ВидДвиженияНакопления.Приход;
				case "Expense":	return ВидДвиженияНакопления.Расход;

				case "Приход":	return ВидДвиженияНакопления.Приход;
				case "Расход":	return ВидДвиженияНакопления.Расход;
			}

			throw new Exception("Недопустимое значение поля \"Value\".");
		}
	}
}
