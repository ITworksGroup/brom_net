namespace ITworks.Brom.Types {
	/// <summary>
	/// Строка дерева значений.
	/// </summary>
	public class СтрокаДереваЗначений : СтрокаДвумернойКоллекцииЗначений {
		internal СтрокаДереваЗначений(ДеревоЗначений дерево):base(дерево) {
			this.rows = new КоллекцияСтрокДереваЗначений(дерево);
		}

		private readonly КоллекцияСтрокДереваЗначений rows;

		/// <summary>
		/// Подчиненные строки дерева значений.
		/// </summary>
		/// <returns></returns>
		public КоллекцияСтрокДереваЗначений Строки() {
			return this.rows;
		}
	}
}
