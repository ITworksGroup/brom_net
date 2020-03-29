using ITworks.Brom.Metadata;

namespace ITworks.Brom.SOAP {
	public partial class MetadataModule {
		public MetadataModule() { }

		internal override УзелМетаданных GetValue(УзелМетаданных родитель) {
			return new МетаданныеМодуль(родитель, this);
		}
	}
}
