namespace ITworks.Brom.Metadata {
	public interface ИКешМетаданных {
		bool ПопыткаПолучитьЗначение(string ключ, out string значение);
		void УстановитьЗначение(string ключ, string значение);
		void Очистить();
		bool СодержитКлюч(string ключ);
	}
}
