using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Строка двумерной коллекции значений.
	/// </summary>
	public abstract class СтрокаДвумернойКоллекцииЗначений : DynamicObject, IEnumerable<KeyValuePair<string, object>> {
		internal СтрокаДвумернойКоллекцииЗначений(ДвумернаяКоллекцияЗначений коллекция) {
			this.parentCollection = коллекция;
			this.values = new Dictionary<КолонкаКоллекцииЗначений, object>();

			this.parentCollection.Колонки.OnColumnRemove += this.Колонки_OnColumnRemove;
		}

		private readonly ДвумернаяКоллекцияЗначений parentCollection;
		private readonly Dictionary<КолонкаКоллекцииЗначений, object> values;

		private void Колонки_OnColumnRemove(object sender, object e) {
			КолонкаКоллекцииЗначений column = e as КолонкаКоллекцииЗначений;
			this.values.Remove(column);
		}

		internal void OnRemove() {
			this.parentCollection.Колонки.OnColumnRemove -= this.Колонки_OnColumnRemove;
		}

		internal object GetByColumn(КолонкаКоллекцииЗначений column) {
			object result = null;
			this.values.TryGetValue(column, out result);
			return result;
		}
		internal void SetByColumn(КолонкаКоллекцииЗначений column, object value) {
			this.values[column] = value;
		}

		public bool TryGetMemberCommon(string fieldName, out object result) {
			КолонкаКоллекцииЗначений column = this.parentCollection.Колонки.Найти(fieldName);
			if (column == null) {
				result = null;
				return false;
			}

			this.values.TryGetValue(column, out result);
			return true;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}

		private bool TrySetMemberCommon(string fieldName, object value) {
			КолонкаКоллекцииЗначений column = this.parentCollection.Колонки.Найти(fieldName);
			if (column == null) {
				return false;
			}

			this.values[column] = value;
			return true;
		}
		public override bool TrySetMember(SetMemberBinder binder, object value) {
			return this.TrySetMemberCommon(binder.Name, value);
		}

		public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
			return this.TrySetMemberCommon((string)indexes[0], value);
		}

		public override IEnumerable<string> GetDynamicMemberNames() {
			return Array.ConvertAll<КолонкаКоллекцииЗначений, string>(
				this.parentCollection.Колонки.ToArray(), 
				new Converter<КолонкаКоллекцииЗначений, string>(val => val.Имя)
			);
		}

		#region IEnumerable
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator() {
			foreach (var column in this.parentCollection.Колонки) {
				yield return new KeyValuePair<string, object>(column.Имя, ((dynamic)this)[column.Имя]);
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			foreach (var column in this.parentCollection.Колонки) {
				yield return new KeyValuePair<string, object>(column.Имя, ((dynamic)this)[column.Имя]);
			}
		}
		#endregion
	}
}
