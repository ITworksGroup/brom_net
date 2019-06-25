using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на объект задачи.
	/// </summary>
	public class ЗадачаСсылка : ОбъектСсылка {
		internal ЗадачаСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.Задача, имяКоллекци, guid) {
		}
	}
}