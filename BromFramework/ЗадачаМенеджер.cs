using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера задачи.
	/// </summary>
	public class ЗадачаМенеджер : ОбъектМенеджер {
		internal ЗадачаМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции, ТипКоллекции.Задача) {
		}

		/// <summary>
		/// Создает контекст объекта задачи.
		/// </summary>
		/// <returns>Возвращает контекст объекта задачи <see cref="ITworks.Brom.ЗадачаОбъект"/>.</returns>
		public ЗадачаОбъект СоздатьЗадачу() {
			return this.СоздатьОбъект() as ЗадачаОбъект;
		}
	}
}
