using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public abstract partial class ValueStructured {
		public override object GetValue(БромКлиент client = null) {
			Структура result = new Структура();
			if (this.Property != null) {
				foreach (var property in this.Property) {
					result.Add(property.Name, property.GetValue(client));
				}
			}

			return result;
		}

		public Структура ToStruct(БромКлиент client = null) {
			Структура result = new Структура();
			if (this.Property != null) {
				foreach (var property in this.Property) {
					result.Add(property.Name, property.GetValue(client));
				}
			}

			return result;
		}

		public ДеревоЗначений ToTree(БромКлиент client = null) {
			ДеревоЗначений дерево = new ДеревоЗначений();
			дерево.Колонки.Добавить("Ключ");
			дерево.Колонки.Добавить("Значение");

			this.PropertyToTreeRow(this.Property, дерево.Строки(), client);

			return дерево;
		}
		private void PropertyToTreeRow(ValueBase[] properties, КоллекцияСтрокДереваЗначений строки, БромКлиент client) {
			if (properties != null) {
				foreach (ValueBase property in properties) {
					dynamic стр = строки.Добавить();
					стр.Ключ = property.Name;
					стр.Значение = property.GetValue(client);

					if (property is ValueStructured) {
						this.PropertyToTreeRow((property as ValueStructured).Property, стр.Строки(), client);
					}
				}
			}
		}
	}
}
