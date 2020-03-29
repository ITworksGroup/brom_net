using System.Collections.Generic;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Дерево значений.
	/// </summary>
    public class ДеревоЗначений : ДвумернаяКоллекцияЗначений {
		public ДеревоЗначений():base() {
			this.rows = new КоллекцияСтрокДереваЗначений(this);
		}

		private readonly КоллекцияСтрокДереваЗначений rows;

		/// <summary>
		/// Строки дерева значений.
		/// </summary>
		/// <returns>Возвращает коллекцию строк дерева значений.</returns>
		public КоллекцияСтрокДереваЗначений Строки() {
			return this.rows;
		}
	}
}
