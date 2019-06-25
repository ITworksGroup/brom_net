namespace ITworks.Brom.Types {
	/// <summary>
	/// Вид границы объекта <see cref="ITworks.Brom.Types.Граница"/>.
	/// </summary>
    public enum ВидГраницы : byte {
		/// <summary>
		/// Включать границу в период.
		/// </summary>
		Включая,
		/// <summary>
		/// Исключать границу из периода.
		/// </summary>
		Исключая
	}
}
