using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueTree {
		public ValueTree() {
			
		}
		public ValueTree(ДеревоЗначений value) {
			if (value == null) {
				throw new System.ArgumentNullException("value");
			}

			this.Column = new DataTableColumn[value.Колонки.Count];
			for (int i = 0; i < value.Колонки.Count; i++) {
				DataTableColumn columnSOAP = new DataTableColumn();
				columnSOAP.Name = value.Колонки[i].Имя;
				this.Column[i] = columnSOAP;
			}

			this.Row = new DataTableRow[value.Строки().Count];
			this.AddRowsSOAP(value, this.Row, value.Строки());
		}
		public ValueTree(object value) : this((ДеревоЗначений)value) { }

		public override object GetValue(БромКлиент client = null) {
			ДеревоЗначений result = new ДеревоЗначений();
			if (this.Column != null) {
				foreach (var column in this.Column) {
					result.Колонки.Добавить(column.Name);
				}
			}
			this.AddRows(result.Строки(), this.Row, client);

			return result;
		}

		public static implicit operator ValueTree(ДеревоЗначений value) {
			return new ValueTree(value);
		}

		private void AddRowsSOAP(ДеревоЗначений tree, DataTableRow[] rowsSOAP, КоллекцияСтрокДереваЗначений rows) {
			for (int i = 0; i < rows.Count; i++) {
				СтрокаДереваЗначений currentRow = rows[i];
				DataTableRow rowSOAP = new DataTableRow();
				rowSOAP.Property = new ValueBase[tree.Колонки.Count];

				for (int j = 0; j < tree.Колонки.Count; j++) {
					string columnName = tree.Колонки[j].Имя;
					ValueBase property = ValueBase.From(((dynamic)currentRow)[columnName]);
					property.Name = columnName;
					rowSOAP.Property[j] = property;
				}
				rowsSOAP[i] = rowSOAP;

				if (currentRow.Строки().Count > 0) {
					rowSOAP.Row = new DataTableRow[currentRow.Строки().Count];
					this.AddRowsSOAP(tree, rowSOAP.Row, currentRow.Строки());
				}
			}
		}
		private void AddRows(КоллекцияСтрокДереваЗначений rows, DataTableRow[] rowsSOAP, БромКлиент client) {
			if (rowsSOAP == null) {
				return;
			}

			foreach (var rowSOAP in rowsSOAP) {
				dynamic currentRow = rows.Добавить();
				if (rowSOAP.Property != null) {
					foreach (ValueBase property in rowSOAP.Property) {
						currentRow[property.Name] = property.GetValue(client);
					}
				}

				this.AddRows(currentRow.Строки(), rowSOAP.Row, client);
			}
		}
	}
}
