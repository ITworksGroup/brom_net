using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера документа.
	/// </summary>
	public class ДокументМенеджер : ОбъектМенеджер {
		internal ДокументМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции, ТипКоллекции.Документ) {
		}

		/// <summary>
		/// Создает контекст объекта документа.
		/// </summary>
		/// <returns>Возвращает контекст объекта документа <see cref="ITworks.Brom.ДокументОбъект"/>.</returns>
		public ДокументОбъект СоздатьДокумент() {
			return this.СоздатьОбъект() as ДокументОбъект;
		}
	}
}
