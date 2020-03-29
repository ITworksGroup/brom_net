namespace ITworks.Brom.Types {
	/// <summary>
	/// Режим записи документа.
	/// </summary>
    public enum РежимЗаписиДокумента : byte {
		/// <summary>
		/// Только запись без проведения.
		/// </summary>
		Запись,
		/// <summary>
		/// Запись с отменой проведения.
		/// </summary>
		ОтменаПроведения,
		/// <summary>
		/// Запись с проведением.
		/// </summary>
		Проведение
	}
}
