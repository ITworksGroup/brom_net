namespace ITworks.Brom.Types {
	/// <summary>
	/// Двумерная коллекция значений. Базовый класс для классов <see cref="ITworks.Brom.Types.ТаблицаЗначений"/> и <see cref="ITworks.Brom.Types.ДеревоЗначений"/>.
	/// </summary>
	public abstract class ДвумернаяКоллекцияЗначений {
		/// <summary>
		/// Основной конструктор двумерной коллекции значений.
		/// </summary>
		protected ДвумернаяКоллекцияЗначений() {
			this.columns = new КоллекцияКолонок();
		}

		private readonly КоллекцияКолонок columns;

		/// <summary>
		/// Коллекция колонок.
		/// </summary>
		public КоллекцияКолонок Колонки {
			get { return this.columns; }
		}
	}
}
