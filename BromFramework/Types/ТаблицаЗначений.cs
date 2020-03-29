using System;
using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.Types
{
    public class ТаблицаЗначений : ДвумернаяКоллекцияЗначений, IReadOnlyList<СтрокаТаблицыЗначений> {
		public ТаблицаЗначений():base() {
			this.rows = new List<СтрокаТаблицыЗначений>();
		}
		internal ТаблицаЗначений(int размерКоллекции) : base() {
			this.rows = new List<СтрокаТаблицыЗначений>(размерКоллекции);
		}

		private readonly List<СтрокаТаблицыЗначений> rows;

		public int Количество() {
			return this.rows.Count;
		}
		public СтрокаТаблицыЗначений Добавить() {
			СтрокаТаблицыЗначений newRow = new СтрокаТаблицыЗначений(this);
			this.rows.Add(newRow);
			return newRow;
		}
		public СтрокаТаблицыЗначений Вставить(int индекс) {
			СтрокаТаблицыЗначений newRow = new СтрокаТаблицыЗначений(this);
			this.rows.Insert(индекс, newRow);
			return newRow;
		}
		public void Удалить(СтрокаТаблицыЗначений строка) {
			if (строка == null) {
				throw new ArgumentNullException("строка");
			}

			this.rows.Remove(строка);
			строка.OnRemove();
		}
		public void Очистить() {
			foreach (СтрокаТаблицыЗначений стр in this.rows) {
				стр.OnRemove();
			}
			this.rows.Clear();
		}
		public СтрокаТаблицыЗначений Получить(int индекс) {
			return this.rows[индекс];
		}

		#region IReadOnlyList methods
		public int Count => ((IReadOnlyList<СтрокаТаблицыЗначений>)this.rows).Count;

		public СтрокаТаблицыЗначений this[int index] => ((IReadOnlyList<СтрокаТаблицыЗначений>)this.rows)[index];

		public IEnumerator<СтрокаТаблицыЗначений> GetEnumerator() {
			return ((IReadOnlyList<СтрокаТаблицыЗначений>)this.rows).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IReadOnlyList<СтрокаТаблицыЗначений>)this.rows).GetEnumerator();
		}
		#endregion
	}
}
