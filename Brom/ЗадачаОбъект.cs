using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст объекта задачи.
	/// </summary>
    public class ЗадачаОбъект : КонтекстОбъекта {
		internal ЗадачаОбъект(ЗадачаСсылка ссылка) : base(ссылка) { }
	}
}
