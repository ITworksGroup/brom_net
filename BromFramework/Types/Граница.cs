using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Граница периода.
	/// </summary>
    public struct Граница {
		/// <summary>
		/// Конструктор границы.
		/// </summary>
		/// <param name="дата">Дата периода.</param>
		/// <param name="видГраницы">Вид границы.</param>
		public Граница(DateTime дата, ВидГраницы видГраницы) {
			this.value = дата;
			this.boundaryType = видГраницы;
		}
		/// <summary>
		/// Конструктор границы.
		/// </summary>
		/// <param name="дата">Дата периода.</param>
		public Граница(DateTime дата):this(дата, ВидГраницы.Включая) {	}

		/// <summary>
		/// Конструктор границы.
		/// </summary>
		/// <param name="моментВремени">Момент времени периода.</param>
		/// <param name="видГраницы">Вид границы.</param>
		public Граница(МоментВремени моментВремени, ВидГраницы видГраницы) {
			this.value = моментВремени;
			this.boundaryType = видГраницы;
		}
		/// <summary>
		/// Конструктор границы.
		/// </summary>
		/// <param name="моментВремени">Момент времени периода.</param>
		public Граница(МоментВремени моментВремени) : this(моментВремени, ВидГраницы.Включая) { }

		private readonly ValueType value;
		private readonly ВидГраницы boundaryType;

		/// <summary>
		/// Дата или момент времени.
		/// </summary>
		public ValueType Значение {
			get { return this.value; }
		}
		/// <summary>
		/// Вид границы.
		/// </summary>
		public ВидГраницы ВидГраницы {
			get { return this.boundaryType; }
		}

	}
}
