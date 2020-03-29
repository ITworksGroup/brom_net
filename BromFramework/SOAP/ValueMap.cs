using ITworks.Brom.Types;
using System.Collections;
using System.Collections.Generic;

namespace ITworks.Brom.SOAP { 
    public partial class ValueMap {
		public ValueMap() {		
		}

		public ValueMap(IDictionary value) : this() {
			if (value == null) {
				throw new System.ArgumentNullException("value");
			}

			this.KeyValue = new ValueKeyValue[value.Count];
			int i = 0;
			foreach (DictionaryEntry keyValue in value) {
				ValueKeyValue keyValueSoap = new ValueKeyValue(keyValue);
				this.KeyValue[i] = keyValueSoap;
				i++;
			}
		}
		public ValueMap(IDictionary<object, object> value) {
			if (value == null) {
				throw new System.ArgumentNullException("value");
			}

			this.KeyValue = new ValueKeyValue[value.Count];
			int i = 0;
			foreach (var keyValue in value) {
				ValueKeyValue keyValueSoap = new ValueKeyValue(keyValue);
				this.KeyValue[i] = keyValueSoap;
				i++;
			}
		}
		public ValueMap(Соответствие value) : this((IDictionary<object, object>)value) { }

		public override object GetValue(БромКлиент client = null) {
			Соответствие result = new Соответствие(this.KeyValue != null ? this.KeyValue.Length : 0);
			if (this.KeyValue != null) {
				foreach (var keyValueSoap in this.KeyValue) {
					result.Add(keyValueSoap.Key.GetValue(client), keyValueSoap.Value.GetValue(client));
				}
			}

			return result;
		}

		public static implicit operator ValueMap(Dictionary<object, object> value) {
			return new ValueMap(value as IDictionary<object, object>);
		}
		public static implicit operator ValueMap(Соответствие value) {
			return new ValueMap(value);
		}
	}
}
