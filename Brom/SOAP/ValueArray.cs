using ITworks.Brom.Types;
using System.Collections;

namespace ITworks.Brom.SOAP { 
    public partial class ValueArray {
		public ValueArray() {
			
		}
		public ValueArray(IList value) {
			this.Item = new ValueBase[value.Count];
			for(int i = 0; i < value.Count; i++) {
				this.Item[i] = ValueBase.From(value[i]);
			}
		}

		public override object GetValue(БромКлиент client = null) {
			if (this.Item == null) {
				return new object[0];
			}

			Массив values = new Массив(this.Item.Length);
			for (int i = 0; i < this.Item.Length; i++) {
				values.Add(this.Item[i].GetValue(client));
			}

			return values;
		}
	}
}
