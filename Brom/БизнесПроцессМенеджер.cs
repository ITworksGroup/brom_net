using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера бизнес-процесса.
	/// </summary>
	public class БизнесПроцессМенеджер : ОбъектМенеджер {
		internal БизнесПроцессМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции, ТипКоллекции.БизнесПроцесс) {
		}

		/// <summary>
		/// Создает контекст объекта бизнес-процесса.
		/// </summary>
		/// <returns>Возвращает контекст объекта бизнес-процесса <see cref="ITworks.Brom.БизнесПроцессОбъект"/>.</returns>
		public БизнесПроцессОбъект СоздатьБизнесПроцесс() {
			return this.СоздатьОбъект() as БизнесПроцессОбъект;
		}
	}
}
