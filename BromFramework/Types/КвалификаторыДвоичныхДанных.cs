namespace ITworks.Brom.Types {
	public class КвалификаторыДвоичныхДанных {
		public КвалификаторыДвоичныхДанных(int длина = 0, ДопустимаяДлина допустимаяДлина = ДопустимаяДлина.Переменная) {
			this.length = длина;
			this.allowedLength = допустимаяДлина;
		}

		private readonly int length;
		private readonly ДопустимаяДлина allowedLength;

		public int Длина {
			get { return this.length; }
		}
		public ДопустимаяДлина ДопустимаяДлина {
			get { return this.allowedLength; }
		}
	}
}
