using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP { 
    public partial class ValueNonserializable {
		public ValueNonserializable() {
		}

		public override object GetValue(БромКлиент client = null) {
			return new НесериализуемыеДанные();
		}
	}
}
