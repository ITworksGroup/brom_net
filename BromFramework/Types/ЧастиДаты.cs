namespace ITworks.Brom.Types {
	/// <summary>
	/// Части даты.
	/// </summary>
	public enum ЧастиДаты : byte {
		/// <summary>
		/// Только время.
		/// </summary>
		Время,
		/// <summary>
		/// Только дата.
		/// </summary>
		Дата,
		/// <summary>
		/// Дата и время.
		/// </summary>
		ДатаВремя
	}
}