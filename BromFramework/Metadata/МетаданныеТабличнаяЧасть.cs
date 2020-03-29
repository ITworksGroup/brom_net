using ITworks.Brom.SOAP;

namespace ITworks.Brom.Metadata {
	public class МетаданныеТабличнаяЧасть : УзелМетаданных {
		internal МетаданныеТабличнаяЧасть(УзелМетаданных родитель, MetadataTableSection metadata) : base(
			родитель.Корень(), 
			родитель, 
			metadata.Name,
			string.Format("{0}.ТабличнаяЧасть.{1}", родитель.ПолноеИмя(), metadata.Name),
			metadata.Title
		) {
			УзелМетаданных.ЗагрузитьРеквизиты(родитель.Корень(), this, metadata.Attribute);
		}
	}
}
