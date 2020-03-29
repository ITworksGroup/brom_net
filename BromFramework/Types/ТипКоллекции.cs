namespace ITworks.Brom.Types
{
	/// <summary>
	/// Тип коллекции 1С.
	/// </summary>
    public enum ТипКоллекции : byte {
		/// <summary>
		/// Справочник.
		/// </summary>
		Справочник,
		/// <summary>
		/// Документ.
		/// </summary>
		Документ,
		/// <summary>
		/// Перечисление.
		/// </summary>
		Перечисление,
		/// <summary>
		/// План видов характеристик.
		/// </summary>
		ПланВидовХарактеристик,
		/// <summary>
		/// План счетов.
		/// </summary>
		ПланСчетов,
		/// <summary>
		/// План видов расчета.
		/// </summary>
		ПланВидовРасчета,
		/// <summary>
		/// Задача.
		/// </summary>
		Задача,
		/// <summary>
		/// Бизнес-процесс.
		/// </summary>
		БизнесПроцесс
    }
}
