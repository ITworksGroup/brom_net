namespace ITworks.Brom {
	/// <summary>
	/// Условие отбора данных.
	/// </summary>
    public class УсловиеОтбора {
		/// <summary>
		/// Конструктор условия отбора.
		/// </summary>
		/// <param name="ключ">Путь к данным поля, например "Производитель.Код".</param>
		/// <param name="значение">Значение сравнения.</param>
		/// <param name="видСравнения">Вид сравнения.</param>
		public УсловиеОтбора(string ключ, object значение, ВидСравнения видСравнения) {
			this.key = ключ;
			this.value = значение;
			this.comparationType = видСравнения;
		}
		/// <summary>
		/// Конструктор условия отбора.
		/// </summary>
		/// <param name="путьКДанным">Путь к данным поля.</param>
		/// <param name="значение">Значение сравнения.</param>
		public УсловиеОтбора(string путьКДанным, object значение):this(путьКДанным, значение, ВидСравнения.Равно) { }

		private readonly string key;
		private readonly object value;
		private readonly ВидСравнения comparationType;

		/// <summary>
		/// Путь к данным поля, например "Производитель.Код".
		/// </summary>
		public string Ключ {
			get { return this.key; }
		}
		/// <summary>
		/// Значение сравнения.
		/// </summary>
		public object Значение {
			get { return this.value; }
		}
		/// <summary>
		/// Вид сравнения.
		/// </summary>
		public ВидСравнения ВидСравнения {
			get { return this.comparationType; }
		}
	}
}
