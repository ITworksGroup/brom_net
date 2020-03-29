using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace ITworks.Brom.Types {
	public class Структура : DynamicObject, IDictionary<string, object> {
		public Структура() {
			this.values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		}
		public Структура(string ключи, params object[] значения) {
			string[] keyNames = ключи.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			this.values = new Dictionary<string, object>(keyNames.Length);

			for (int i = 0; i < keyNames.Length; i++) {
				object value = i < значения.Length ? значения[i] : null;
				this.Add(keyNames[i].Trim(), value);
			}
		}
		internal Структура(int размерКоллекции) {
			this.values = new Dictionary<string, object>(размерКоллекции, StringComparer.OrdinalIgnoreCase);
		}

		private Dictionary<string, object> values;

		static Структура() {
			Структура.regex = new Regex(@"[A-Za-zА-Яа-я_]{1}[A-Za-zА-Яа-я_0-9]*");
		}
		private static bool IsPropertyNameValid(string name) {
			return Структура.regex.Match(name).Value == name;
		}

		private static Regex regex;

		public bool Свойство(string ключ, out object значение) {
			return this.TryGetValue(ключ, out значение);
		}
		public bool Свойство(string ключ) {
			return this.ContainsKey(ключ);
		}
		public void Вставить(string ключ, object значение = null) {
			this.Add(ключ, значение);
		}
		public void Очистить() {
			this.Clear();
		}
		public int Количество() {
			return this.Count;
		}
		public bool Удалить(string ключ) {
			return this.Remove(ключ);
		}

		#region DynamicObject
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.values.TryGetValue(binder.Name, out result);
		}

		public override bool TrySetMember(SetMemberBinder binder, object value) {
			if (this.values.ContainsKey(binder.Name)) {
				this.values[binder.Name] = value;
				return true;
			}
			return false;
		}
		#endregion

		#region IDictionary 
		public ICollection<string> Keys => ((IDictionary<string, object>)this.values).Keys;

		public ICollection<object> Values => ((IDictionary<string, object>)this.values).Values;

		public int Count => ((IDictionary<string, object>)this.values).Count;

		public bool IsReadOnly => ((IDictionary<string, object>)this.values).IsReadOnly;

		public object this[string key] {
			get {
				if (!Структура.IsPropertyNameValid(key)) {
					throw new ArgumentException("Недопустимое имя поля.", "key");
				}

				return ((IDictionary<string, object>)this.values)[key];
			}
			set {
				if (!Структура.IsPropertyNameValid(key)) {
					throw new ArgumentException("Недопустимое имя поля.", "key");
				}

				((IDictionary<string, object>)this.values)[key] = value;
			}
		}

		public void Add(string key, object value) {
			if (!Структура.IsPropertyNameValid(key)) {
				throw new ArgumentException("Недопустимое имя поля.", "key");
			}

			((IDictionary<string, object>)this.values).Add(key, value);
		}

		public bool ContainsKey(string key) {
			return ((IDictionary<string, object>)this.values).ContainsKey(key);
		}

		public bool Remove(string key) {
			return ((IDictionary<string, object>)this.values).Remove(key);
		}

		public bool TryGetValue(string key, out object value) {
			return ((IDictionary<string, object>)this.values).TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<string, object> item) {
			if (!Структура.IsPropertyNameValid(item.Key)) {
				throw new ArgumentException("Недопустимое имя поля.", "key");
			}

			((IDictionary<string, object>)this.values).Add(item);
		}

		public void Clear() {
			((IDictionary<string, object>)this.values).Clear();
		}

		public bool Contains(KeyValuePair<string, object> item) {
			return ((IDictionary<string, object>)this.values).Contains(item);
		}

		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) {
			((IDictionary<string, object>)this.values).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, object> item) {
			return ((IDictionary<string, object>)this.values).Remove(item);
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator() {
			return ((IDictionary<string, object>)this.values).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IDictionary<string, object>)this.values).GetEnumerator();
		}
		#endregion
	}
}
