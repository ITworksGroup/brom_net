using ITworks.Brom.SOAP;

namespace ITworks.Brom.Metadata {
	public class МетаданныеРеквизит : УзелМетаданных {
		internal МетаданныеРеквизит(УзелМетаданных родитель, MetadataAttribute metadata) : base(
			родитель.Корень(), 
			родитель, 
			metadata.Name, 
			string.Format("{0}.Реквизит.{1}", родитель.ПолноеИмя(), metadata.Name), 
			metadata.Title
		) { }
	}
}
