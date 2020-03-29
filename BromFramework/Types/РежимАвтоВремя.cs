namespace ITworks.Brom.Types {
	/// <summary>
	/// Режим автоматической установки времени.
	/// </summary>
    public enum РежимАвтоВремя : byte {
		/// <summary>
		/// Не использовать.
		/// </summary>
		НеИспользовать,
		/// <summary>
		/// Первыь.
		/// </summary>
		Первым,
		/// <summary>
		/// Последним.
		/// </summary>
		Последним,
		/// <summary>
		/// Текущее или первым.
		/// </summary>
		ТекущееИлиПервым,
		/// <summary>
		/// Текущее или последним.
		/// </summary>
		ТекущееИлиПоследним
	}
}
