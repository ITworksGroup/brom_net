using ITworks.Brom.SOAP;

namespace ITworks.Brom.Metadata {
	public class МетаданныеМодуль : УзелМетаданных {
		internal МетаданныеМодуль(УзелМетаданных родитель, MetadataModule metadata) : base(родитель.Корень(), родитель, metadata.Name, metadata.FullName, metadata.Title) {
		}
	}
}
