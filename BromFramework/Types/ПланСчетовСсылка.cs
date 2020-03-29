using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на объект плана счетов.
	/// </summary>
	public class ПланСчетовСсылка : ОбъектСсылка {
		internal ПланСчетовСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.ПланСчетов, имяКоллекци, guid) {
		}
	}
}