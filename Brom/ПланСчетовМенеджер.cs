using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера плана счетов.
	/// </summary>
	public class ПланСчетовМенеджер : ОбъектМенеджер {
		internal ПланСчетовМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции, ТипКоллекции.ПланСчетов) {
		}

		/// <summary>
		/// Создает контекст объекта счета.
		/// </summary>
		/// <returns>Возвращает контекст объекта счета <see cref="ITworks.Brom.ПланСчетовОбъект"/>.</returns>
		public ПланСчетовОбъект СоздатьСчет() {
			return this.СоздатьОбъект() as ПланСчетовОбъект;
		}
	}
}
