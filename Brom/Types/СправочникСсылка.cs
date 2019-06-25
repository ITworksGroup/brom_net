using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на объект элемента справочника.
	/// </summary>
    public class СправочникСсылка : ОбъектСсылка{
		internal СправочникСсылка(БромКлиент клиент, string имяКоллекци, Guid guid):base(клиент, ITworks.Brom.Types.ТипКоллекции.Справочник, имяКоллекци, guid) {
		}
	}
}
