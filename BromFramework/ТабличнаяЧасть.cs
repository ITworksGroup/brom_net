using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ITworks.Brom {
	/// <summary>
	/// Табличная часть.
	/// </summary>
	public class ТабличнаяЧасть : IReadOnlyList<СтрокаТабличнойЧасти> {
		internal ТабличнаяЧасть(МетаданныеТабличнаяЧасть метаданные) {
			this.metadata = метаданные ?? throw new ArgumentNullException("метаданные");
			this.rows = new List<СтрокаТабличнойЧасти>();
		}
		internal ТабличнаяЧасть(МетаданныеТабличнаяЧасть метаданные, int размерКоллекции) {
			this.metadata = метаданные ?? throw new ArgumentNullException("метаданные");
			this.rows = new List<СтрокаТабличнойЧасти>(размерКоллекции);
		}

		private МетаданныеТабличнаяЧасть metadata;

		/// <summary>
		/// Строки табличной части.
		/// </summary>
		protected readonly List<СтрокаТабличнойЧасти> rows;

		/// <summary>
		/// Метаданные табличной части.
		/// </summary>
		/// <returns></returns>
		public МетаданныеТабличнаяЧасть Метаданные() {
			return this.metadata;
		}

		/// <summary>
		/// Количество строк табличной части.
		/// </summary>
		/// <returns>Возвращает количество строк табличной части.</returns>
		public int Количество() {
			return this.Count;
		}

		/// <summary>
		/// Добавляет строку табличной части.
		/// </summary>
		/// <returns>Возвращает строку табличной части, которая была добавлена.</returns>
		protected СтрокаТабличнойЧасти ДобавитьСтроку() {
			СтрокаТабличнойЧасти стр = new СтрокаТабличнойЧасти(this);
			this.rows.Add(стр);
			return стр;
		}
		/// <summary>
		/// Удалить строку табличной части.
		/// </summary>
		/// <param name="строка">Строка табличной части.</param>
		protected void УдалитьСтроку(СтрокаТабличнойЧасти строка) {
			this.rows.Remove(строка);
		}

		internal void ЗагрузитьДанные(ТаблицаЗначений таблица) {
			IEnumerable<string> поляТаблица	= таблица.Колонки.Наименования();
			IEnumerable<string> поляТаблЧасть = this.metadata.НайтиПодчиненный("Реквизиты").GetDynamicMemberNames();
			IEnumerable<string> общиеПоля = поляТаблЧасть.Intersect(поляТаблица, StringComparer.OrdinalIgnoreCase);

			this.rows.Clear();
			foreach (dynamic стр in таблица) {
				СтрокаТабличнойЧасти новСтр = this.ДобавитьСтроку();
				foreach (string имяПоля in общиеПоля) {
					новСтр.УстановитьЗначение(имяПоля, стр[имяПоля]);
				}
			}
		}

		/// <summary>
		/// Выгружает табличную часть в таблицу значений (<see cref="ITworks.Brom.Types.ТаблицаЗначений"/>).
		/// </summary>
		/// <returns>Возвращает таблицу значений, содержащую данные табличной части.</returns>
		public ТаблицаЗначений Выгрузить() {
			ТаблицаЗначений таблица = new ТаблицаЗначений(this.Count);
			IEnumerable<string> именаПолей = this.metadata.Найти("Реквизиты").GetDynamicMemberNames();
			foreach (string имяПоля in именаПолей) {
				таблица.Колонки.Добавить(имяПоля);
			}

			foreach (dynamic стр in this.rows) {
				dynamic новСтр = таблица.Добавить();
				foreach (string имяПоля in именаПолей) {
					новСтр[имяПоля] = стр[имяПоля];
				}
			}

			return таблица;
		}

		#region IReadOnlyList
		public int Count => this.rows.Count;

		public СтрокаТабличнойЧасти this[int index] => this.rows[index];

		public IEnumerator<СтрокаТабличнойЧасти> GetEnumerator() {
			return ((IReadOnlyList<СтрокаТабличнойЧасти>)this.rows).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IReadOnlyList<СтрокаТабличнойЧасти>)this.rows).GetEnumerator();
		}
		#endregion

		/// <summary>
		/// Строковое представление табличной части.
		/// </summary>
		/// <returns>Возвращает строковое представление табличной части.</returns>
		public override string ToString() {
			return this.metadata.ПолноеИмя();
		}

	}
}
