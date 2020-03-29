using ITworks.Brom.Metadata;

namespace ITworks.Brom.SOAP {
	public partial class MetadataAttribute {
		public MetadataAttribute() { }

		internal override УзелМетаданных GetValue(УзелМетаданных родитель) {
			return new МетаданныеРеквизит(родитель, this);
		}
	}
}
