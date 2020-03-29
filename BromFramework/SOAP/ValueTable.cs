using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueTable {
		public ValueTable() {
			
		}
		public ValueTable(ТаблицаЗначений value) {
			if (value == null) {
				throw new System.ArgumentNullException("value");
			}

			this.Column = new DataTableColumn[value.Колонки.Count];
			for (int i = 0; i < value.Колонки.Count; i++) {
				DataTableColumn columnSOAP = new DataTableColumn();
				columnSOAP.Name = value.Колонки[i].Имя;
				this.Column[i] = columnSOAP;
			}

			this.Row = new DataTableRow[value.Count];
			for (int i = 0; i < value.Count; i++) {
				DataTableRow rowSOAP = new DataTableRow();
				rowSOAP.Property = new ValueBase[value.Колонки.Count];

				for (int j = 0; j < value.Колонки.Count; j++) {
					КолонкаКоллекцииЗначений column = value.Колонки[j];
					ValueBase property = ValueBase.From(((dynamic)value[i]).GetByColumn(column));
					property.Name = column.Имя;
					rowSOAP.Property[j] = property;
				}
				this.Row[i] = rowSOAP;
			}
		}
		public ValueTable(object value) : this((ТаблицаЗначений)value) { }

		public override object GetValue(БромКлиент client = null) {
			ТаблицаЗначений result = new ТаблицаЗначений();
			if (this.Column != null) {
				foreach (var column in this.Column) {
					result.Колонки.Добавить(column.Name);
				}
			}
			if (this.Row != null) {
				foreach (var row in this.Row) {
					dynamic temRow = result.Добавить();
					if (row.Property != null) {
						foreach (var property in row.Property) {
							temRow[property.Name] = property.GetValue(client);
						}
					}
				}
			}

			return result;
		}

		public static implicit operator ValueTable(ТаблицаЗначений value) {
			return new ValueTable(value);
		}
	}
}
