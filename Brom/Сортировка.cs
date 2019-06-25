namespace ITworks.Brom {
	/// <summary>
	/// Сортировка данных.
	/// </summary>
    public class Сортировка {
		/// <summary>
		/// Конструктор сортировки данных.
		/// </summary>
		/// <param name="ключ">Путь к данным поля, по которому происходит упорядочение, например "Производитель.Код".</param>
		/// <param name="направлениеСортировки">Направление сортировки.</param>
		public Сортировка(string ключ, НаправлениеСортировки направлениеСортировки = НаправлениеСортировки.Возрастание) {
			this.key = ключ;
			this.sortDirection = направлениеСортировки;
		}

		private readonly string key;
		private НаправлениеСортировки sortDirection;

		/// <summary>
		/// Путь к данным поля, по которому происходит упорядочение, например "Производитель.Код".
		/// </summary>
		public string Ключ {
			get { return this.key; }
		}
		/// <summary>
		/// Направление сортировки.
		/// </summary>
		public НаправлениеСортировки Направление {
			get { return this.sortDirection; }
			set { this.sortDirection = value; }
		}
	}
}
