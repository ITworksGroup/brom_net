using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст объекта счета.
	/// </summary>
    public class ПланСчетовОбъект : КонтекстОбъекта {
		internal ПланСчетовОбъект(ПланСчетовСсылка ссылка) : base(ссылка) { }
	}
}
