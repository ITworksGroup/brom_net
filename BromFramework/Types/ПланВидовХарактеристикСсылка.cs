using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на объект плана видов характеристик.
	/// </summary>
	public class ПланВидовХарактеристикСсылка : ОбъектСсылка {
		internal ПланВидовХарактеристикСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.ПланВидовХарактеристик, имяКоллекци, guid) {
		}
	}
}
