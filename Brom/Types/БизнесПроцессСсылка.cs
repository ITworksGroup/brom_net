using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Сыслка на объект бизнес-процесса. 
	/// </summary>
	public class БизнесПроцессСсылка : ОбъектСсылка {
		internal БизнесПроцессСсылка(БромКлиент клиент, string имяКоллекци, Guid guid) : base(клиент, ITworks.Brom.Types.ТипКоллекции.БизнесПроцесс, имяКоллекци, guid) {
		}
	}
}
