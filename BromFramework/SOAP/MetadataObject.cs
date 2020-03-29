using System;
using ITworks.Brom.Metadata;
using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP {
	public partial class MetadataObject {
		public MetadataObject() { }

		internal override УзелМетаданных GetValue(УзелМетаданных родитель) {
			return new МетаданныеОбъект(родитель, this);
		}
	}
}
