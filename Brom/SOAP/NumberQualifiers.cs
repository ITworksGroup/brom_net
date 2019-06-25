using ITworks.Brom.Types;

namespace ITworks.Brom.SOAP {
	public partial class NumberQualifiers {
		public NumberQualifiers() {
		}
		public NumberQualifiers(КвалификаторыЧисла квалификаторы) {
			this.Digits = квалификаторы.Разрядность;
			this.FractionDigits = квалификаторы.РазрядностьДробнойЧасти;
			this.OnlyPositive = квалификаторы.ДопустимыйЗнак == ДопустимыЗнак.Неотрицательный;
		}

		public КвалификаторыЧисла GetValue() {
			return new КвалификаторыЧисла(this.Digits, this.FractionDigits, this.OnlyPositive ? ДопустимыЗнак.Неотрицательный : ДопустимыЗнак.Любой);
		}
	}
}
