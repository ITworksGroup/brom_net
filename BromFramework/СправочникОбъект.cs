using ITworks.Brom.Types;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст объекта элемента/группы справочника.
	/// </summary>
    public class СправочникОбъект : КонтекстОбъекта {
		internal СправочникОбъект(СправочникСсылка ссылка) : base(ссылка) { }
	}
}
