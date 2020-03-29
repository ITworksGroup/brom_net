using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на обект плана видов расчета.
	/// </summary>
	public class ПланВидовРасчетаСсылка : ОбъектСсылка {
		internal ПланВидовРасчетаСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.ПланВидовРасчета, имяКоллекци, guid) {
		}
	}
}