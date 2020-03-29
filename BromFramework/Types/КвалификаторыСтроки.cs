namespace ITworks.Brom.Types {
	public class КвалификаторыСтроки {
		public КвалификаторыСтроки(int длинаСтроки = 0, ДопустимаяДлина допустимаяДлина = ДопустимаяДлина.Переменная) {
			this.length = длинаСтроки;
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
