using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на объект документа.
	/// </summary>
	public class ДокументСсылка : ОбъектСсылка {
		internal ДокументСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.Документ, имяКоллекци, guid) {
		}
	}
}