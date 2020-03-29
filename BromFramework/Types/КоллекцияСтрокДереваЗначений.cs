using System;
using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.Types {
    public class КоллекцияСтрокДереваЗначений : IReadOnlyList<СтрокаДереваЗначений> {
		internal КоллекцияСтрокДереваЗначений(ДеревоЗначений дерево) {
			this.parentCollection = дерево;
			this.rows = new List<СтрокаДереваЗначений>();
		}

		private ДеревоЗначений parentCollection;
		private List<СтрокаДереваЗначений> rows;

		public int Количество() {
			return this.rows.Count;
		}
		public СтрокаДереваЗначений Добавить() {
			СтрокаДереваЗначений newRow = new СтрокаДереваЗначений(this.parentCollection);
			this.rows.Add(newRow);
			return newRow;
		}
		public СтрокаДереваЗначений Вставить(int индекс) {
			СтрокаДереваЗначений newRow = new СтрокаДереваЗначений(this.parentCollection);
			this.rows.Insert(индекс, newRow);
			return newRow;
		}
		public void Удалить(СтрокаДереваЗначений строка) {
			if (строка == null) {
				throw new ArgumentNullException("строка");
			}

			строка.OnRemove();
			this.rows.Remove(строка);
		}
		public void Очистить() {
			foreach (СтрокаДереваЗначений стр in this.rows) {
				стр.OnRemove();
			}
			this.rows.Clear();
		}
		public СтрокаДереваЗначений Получить(int индекс) {
			return this.rows[индекс];
		}

		#region IReadOnlyList
		public int Count => ((IReadOnlyList<СтрокаДереваЗначений>)this.rows).Count;

		public СтрокаДереваЗначений this[int index] => ((IReadOnlyList<СтрокаДереваЗначений>)this.rows)[index];

		
		public IEnumerator<СтрокаДереваЗначений> GetEnumerator() {
			return ((IReadOnlyList<СтрокаДереваЗначений>)this.rows).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IReadOnlyList<СтрокаДереваЗначений>)this.rows).GetEnumerator();
		}
		#endregion
	}
}
