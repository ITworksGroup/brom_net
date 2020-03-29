namespace ITworks.Brom.Types {
	/// <summary>
	/// Вид точки маршрута бизнес-процесса.
	/// </summary>
    public enum ВидТочкиМаршрутаБизнесПроцесса : byte {
		/// <summary>
		/// Вложенный бизнес-процесс.
		/// </summary>
		ВложенныйБизнесПроцесс,
		/// <summary>
		/// Выбор варианта.
		/// </summary>
		ВыборВарианта,
		/// <summary>
		/// Действие.
		/// </summary>
		Действие,
		/// <summary>
		/// Завершение.
		/// </summary>
		Завершение,
		/// <summary>
		/// Обработка.
		/// </summary>
		Обработка,
		/// <summary>
		/// Разделение.
		/// </summary>
		Разделение,
		/// <summary>
		/// Слияние.
		/// </summary>
		Слияние,
		/// <summary>
		/// Старт.
		/// </summary>
		Старт,
		/// <summary>
		/// Условие.
		/// </summary>
		Условие
	}
}
