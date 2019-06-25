using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст объекта бизнес-процесса.
	/// </summary>
    public class БизнесПроцессОбъект : КонтекстОбъекта {
		internal БизнесПроцессОбъект(БизнесПроцессСсылка ссылка) : base(ссылка) { }
	}
}
