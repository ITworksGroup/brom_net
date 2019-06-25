namespace ITworks.Brom {
	/// <summary>
	/// Поле данных.
	/// </summary>
    public struct ПолеДанных {
		/// <summary>
		/// Конструктор поля данных.
		/// </summary>
		/// <param name="ключ">Путь к данным поля, например "Производитель.Код".</param>
		/// <param name="псевдоним">Псевдоним поля.</param>
		public ПолеДанных(string ключ, string псевдоним) {
			this.key = ключ;
			this.name = псевдоним;
		}
		/// <summary>
		/// Конструктор поля данных.
		/// </summary>
		/// <param name="ключ">Путь к данным поля, например "Производитель.Код".</param>
		public ПолеДанных(string ключ):this(ключ, null) { }

		private readonly string key;
		private readonly string name;

		/// <summary>
		/// Путь к данным поля, например "Производитель.Код".
		/// </summary>
		public string Ключ {
			get { return this.key; }
		}
		/// <summary>
		/// Псевдоним поля.
		/// </summary>
		public string Псевдоним {
			get { return this.name; }
		}
	}
}
