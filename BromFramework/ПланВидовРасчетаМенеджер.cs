using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера плана видов расчета.
	/// </summary>
	public class ПланВидовРасчетаМенеджер : ОбъектМенеджер {
		internal ПланВидовРасчетаМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции):base(bromClient, метаданныеКоллекции, ТипКоллекции.ПланВидовРасчета) {
		}

		/// <summary>
		/// Создает контекст объекта счета.
		/// </summary>
		/// <returns>Возвращает контекст объекта вида расчета <see cref="ITworks.Brom.ПланВидовРасчетаОбъект"/>.</returns>
		public ПланВидовРасчетаОбъект СоздатьВидРасчета() {
			return this.СоздатьОбъект() as ПланВидовРасчетаОбъект;
		}
	}
}
