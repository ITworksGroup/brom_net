namespace ITworks.Brom.Types {
	/// <summary>
	/// Хранилище значения.
	/// </summary>
    public class ХранилищеЗначения {
		/// <summary>
		/// Конструктор хранилища значения.
		/// </summary>
		/// <param name="значение">Сохраняемое значение.</param>
		public ХранилищеЗначения(object значение) {
			this.data = значение;
		}

		private readonly dynamic data;

		/// <summary>
		/// Возвращает значение, содержащееся в хранилище.
		/// </summary>
		/// <returns>Возвращает значение, содержащееся в хранилище.</returns>
		public dynamic Получить() {
			return this.data;
		}
		/// <summary>
		/// Возвращает значение, содержащееся в хранилище, с приведением к указанному типу.
		/// </summary>
		/// <typeparam name="T">Тип, к которому будет приведено значение.</typeparam>
		/// <returns>Возвращает значение, содержащееся в хранилище, с приведением к указанному типу.</returns>
		public T Получить<T>() {
			return (T)this.data;
		}
	}
}
