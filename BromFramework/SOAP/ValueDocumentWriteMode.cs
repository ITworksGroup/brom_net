using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueDocumentWriteMode {
		public ValueDocumentWriteMode() {			
		}
		public ValueDocumentWriteMode(РежимЗаписиДокумента значение) {
			this.Value = значение.ToString();
		}
		public ValueDocumentWriteMode(object value) : this((РежимЗаписиДокумента)value) { }

		public override object GetValue(БромКлиент client = null) {
			switch (this.Value) {
				case "Write":
					return РежимЗаписиДокумента.Запись;
				case "UndoPosting":
					return РежимЗаписиДокумента.ОтменаПроведения;
				case "Posting":
					return РежимЗаписиДокумента.Проведение;

				case "Запись":
					return РежимЗаписиДокумента.Запись;
				case "ОтменаПроведения":
					return РежимЗаписиДокумента.ОтменаПроведения;
				case "Проведение":
					return РежимЗаписиДокумента.Проведение;
			}

			throw new Exception("Недопустимое значение поля \"Value\".");
		}
	}
}
