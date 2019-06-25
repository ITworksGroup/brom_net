using ITworks.Brom.Types;
using System;

namespace ITworks.Brom.SOAP { 
    public partial class PostObject_Settings {
		public PostObject_Settings() {
		}

		public PostObject_Settings(Структура допСвойства, РежимЗаписиДокумента режимЗаписи, РежимПроведенияДокумента режимПроведения, bool режимЗагрузки) {
			this.AdditionalProperties = ValueBase.From(допСвойства) as ValueStruct;
			this.ExchangeLoadMode = режимЗагрузки;
			this.ExchangeLoadModeSpecified = режимЗагрузки;
			this.DocumentWriteMode = режимЗаписи.ToString();
			this.DocumentPostingMode = режимПроведения.ToString();
		}
	}
}
