namespace ITworks.Brom.Types {
	public class КвалификаторыЧисла {
		public КвалификаторыЧисла(int числоРазрядов = 0, int числоРазрядовДробнойЧасти = 0, ДопустимыЗнак допустимыйЗнак = ДопустимыЗнак.Любой) {
			this.digits = числоРазрядов;
			this.fractionDigits = числоРазрядовДробнойЧасти;
			this.allowedSign = допустимыйЗнак;
		}

		private readonly int digits;
		private readonly int fractionDigits;
		private readonly ДопустимыЗнак allowedSign;

		public int Разрядность {
			get { return this.digits; }
		}
		public int РазрядностьДробнойЧасти {
			get { return this.fractionDigits; }
		}
		public ДопустимыЗнак ДопустимыйЗнак {
			get { return this.allowedSign; }
		}
	}
}
