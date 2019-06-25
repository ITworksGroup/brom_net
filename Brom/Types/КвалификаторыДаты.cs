namespace ITworks.Brom.Types {
	public class КвалификаторыДаты {
		public КвалификаторыДаты(ЧастиДаты частиДаты = ЧастиДаты.ДатаВремя) {
			this.dateFractions = частиДаты;
		}

		private readonly ЧастиДаты dateFractions;

		public ЧастиДаты ЧастиДаты {
			get { return this.dateFractions; }
		}
	}
}
