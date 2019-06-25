using System;
using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.Types {
	public class КоллекцияКолонок : IReadOnlyList<КолонкаКоллекцииЗначений> {
		internal КоллекцияКолонок() {
			this.columns = new List<КолонкаКоллекцииЗначений>();
		}

		private List<КолонкаКоллекцииЗначений> columns;

		private event EventHandler<object> onColumnAdd;
		private event EventHandler<object> onColumnRemove;
		private event EventHandler<object> onColumnRename;

		public void Добавить(string имя, string заголовок = null) {
			if (this.Найти(имя) != null ) {
				throw new Exception(String.Format("Колонка с именем \"{0}\" уже присутствует в таблице.", имя));
			}

			КолонкаКоллекцииЗначений column = new КолонкаКоллекцииЗначений(имя, заголовок);
			column.OnStartRename += this.Column_OnStartRename;
			column.OnRename += this.Column_OnRename;

			this.columns.Add(column);
			this.onColumnAdd?.Invoke(this, column);
		}

		public string[] Наименования() {
			return this.columns.ConvertAll<string>(new Converter<КолонкаКоллекцииЗначений, string>(val => val.Имя)).ToArray();
		}

		private void Column_OnStartRename(object sender, object e) {
			string oldName = ((dynamic)e).oldName;
			string newName = ((dynamic)e).newName;
			if (!String.Equals(oldName, newName, StringComparison.OrdinalIgnoreCase) && this.Найти(newName) != null) {
				throw new Exception(String.Format("Колонка с именем \"{0}\" уже присутствует в таблице.", newName));
			}
		}
		private void Column_OnRename(object sender, object e) {
			this.onColumnRename?.Invoke(this, e);
		}

		public int Количество() {
			return this.Count;
		}
		public void Вставить(int индекс, string имя, string заголовок = null) {
			if (this.Найти(имя) != null) {
				throw new Exception(String.Format("Колонка с именем \"{0}\" уже присутствует в таблице.", имя));
			}

			КолонкаКоллекцииЗначений column = new КолонкаКоллекцииЗначений(имя, заголовок);
			this.columns.Insert(индекс, column);
			this.onColumnAdd?.Invoke(this, column);
		}
		public КолонкаКоллекцииЗначений Найти(string имяКолонки) {
			return this.columns.Find(val => String.Equals(val.Имя, имяКолонки, StringComparison.OrdinalIgnoreCase));
		}
		public void Удалить(int индекс) {
			КолонкаКоллекцииЗначений tempColumn = this.columns[индекс];
			this.columns.Remove(tempColumn);
			this.onColumnRemove?.Invoke(this, tempColumn);
		}
		public void Удалить(КолонкаКоллекцииЗначений колонка) {
			if (this.columns.Contains(колонка)) {
				this.columns.Remove(колонка);
				this.onColumnRemove?.Invoke(this, колонка);
			}
		}
		public void Удалить(string имяКолонки) {
			КолонкаКоллекцииЗначений tempColumn = this.Найти(имяКолонки);
			if (tempColumn != null) {
				this.columns.Remove(tempColumn);
				this.onColumnRemove?.Invoke(this, tempColumn);
			}
		}

		public event EventHandler<object> OnColumnAdd {
			add {
				this.onColumnAdd += value;
			}
			remove {
				this.onColumnAdd -= value;
			}
		}
		public event EventHandler<object> OnColumnRemove {
			add {
				this.onColumnRemove += value;
			}
			remove {
				this.onColumnRemove -= value;
			}
		}
		public event EventHandler<object> OnColumnRename {
			add {
				this.onColumnRename += value;
			}
			remove {
				this.onColumnRename -= value;
			}
		}

		#region IReadOnlyList methods
		public КолонкаКоллекцииЗначений this[int index] => ((IReadOnlyList<КолонкаКоллекцииЗначений>)this.columns)[index];

		public int Count => ((IReadOnlyList<КолонкаКоллекцииЗначений>)this.columns).Count;

		public IEnumerator<КолонкаКоллекцииЗначений> GetEnumerator() {
			return ((IReadOnlyList<КолонкаКоллекцииЗначений>)this.columns).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IReadOnlyList<КолонкаКоллекцииЗначений>)this.columns).GetEnumerator();
		}
		#endregion
	}
}
