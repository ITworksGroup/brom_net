using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.SOAP { 
    public partial class ValueKeyValue {
		public ValueKeyValue() {
			
		}

		public ValueKeyValue(KeyValuePair<object, object> value) {
			this.Key = ValueBase.From(value.Key);
			this.Value = ValueBase.From(value.Value);
		}
		public ValueKeyValue(DictionaryEntry value) {
			this.Key = ValueBase.From(value.Key);
			this.Value = ValueBase.From(value.Value);
		}
		public ValueKeyValue(object key, object value) {
			this.Key = ValueBase.From(key);
			this.Value = ValueBase.From(value);
		}

		public override object GetValue(БромКлиент client = null) {
			return new KeyValuePair<object, object>(this.Key.GetValue(client), this.Value.GetValue(client));
		}

		public static implicit operator ValueKeyValue(KeyValuePair<object, object> value) {
			return new ValueKeyValue(value);
		}
	}
}
