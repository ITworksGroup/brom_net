using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueAccountType {
		public ValueAccountType() {			
		}
		public ValueAccountType(ВидСчета значение) {
			this.Value = значение.ToString();
		}
		public ValueAccountType(object value) : this((ВидСчета)value) { }

		public override object GetValue(БромКлиент client = null) {
			switch (this.Value) {
				case "ActivePassive":
					return ВидСчета.АктивноПассивный;
				case "Active":
					return ВидСчета.Активный;
				case "Passive":
					return ВидСчета.Пассивный;

				case "АктивноПассивный":
					return ВидСчета.АктивноПассивный;
				case "Активный":
					return ВидСчета.Активный;
				case "Пассивный":
					return ВидСчета.Пассивный;
			}

			throw new Exception("Недопустимое значение поля \"Value\".");
		}
	}
}
