using System.Collections.Generic;

namespace ITworks.Brom.Types {
	public class Соответствие : Dictionary<object, object> {
		public Соответствие() : base() { }
		internal Соответствие(int размерКоллекции) : base(размерКоллекции) {
		}

		public void Вставить(object ключ, object значение) {
			this.Add(ключ, значение);
		}
		public int Количество() {
			return this.Count;
		}
		public void Очистить() {
			this.Clear();
		}
		public object Получить(object ключ) {
			object value = null;
			if( this.TryGetValue(ключ, out value)) {
				return value;
			}

			return null;
		}
		public void Удалить(object ключ) {
			this.Remove(ключ);
		}
	}
}
