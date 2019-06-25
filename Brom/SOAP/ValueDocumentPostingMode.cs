using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class ValueDocumentPostingMode {
		public ValueDocumentPostingMode() {			
		}
		public ValueDocumentPostingMode(РежимПроведенияДокумента значение) {
			this.Value = значение.ToString();
		}
		public ValueDocumentPostingMode(object value) : this((РежимПроведенияДокумента)value) { }

		public override object GetValue(БромКлиент client = null) {
			switch (this.Value) {
				case "Regular":
					return РежимПроведенияДокумента.Неоперативный;
				case "RealTime":
					return РежимПроведенияДокумента.Оперативный;

				case "Неоперативный":
					return РежимПроведенияДокумента.Неоперативный;
				case "Оперативный":
					return РежимПроведенияДокумента.Оперативный;
			}

			throw new Exception("Недопустимое значение поля \"Value\".");
		}
	}
}
