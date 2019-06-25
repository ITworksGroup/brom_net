namespace ITworks.Brom.Types {
	/// <summary>
	/// Вид движения регистра бухгалтерии.
	/// </summary>
    public enum ВидДвиженияБухгалтерии : byte {
		/// <summary>
		/// Дебетовое движение.
		/// </summary>
		Дебет,
		/// <summary>
		/// Кредитовое движение.
		/// </summary>
		Кредит
	}
}
