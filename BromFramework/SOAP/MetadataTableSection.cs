using ITworks.Brom.Metadata;

namespace ITworks.Brom.SOAP {
	public partial class MetadataTableSection {
		public MetadataTableSection() { }

		internal override УзелМетаданных GetValue(УзелМетаданных родитель) {
			return new МетаданныеТабличнаяЧасть(родитель, this);
		}
	}
}
