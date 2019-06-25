using System;

namespace ITworks.Brom.Types {
	/// <summary>
	/// Ссылка на элемент перечисления.
	/// </summary>
    public class ПеречислениеСсылка : Ссылка {
		internal ПеречислениеСсылка(БромКлиент клиент, string имяКоллекци, string имя):base(клиент, ITworks.Brom.Types.ТипКоллекции.Перечисление, имяКоллекци) {
			this.name = !String.IsNullOrEmpty(имя) ? имя : String.Empty;
		}
		internal ПеречислениеСсылка(БромКлиент клиент, string имяКоллекци) : this(клиент, имяКоллекци, null) { }

		private readonly string name;

		/// <summary>
		/// Имя элемента перечисления.
		/// </summary>
		public string Имя {
			get { return this.name; }
		}


		/// <summary>
		/// Определяет является ли ссылка пустой.
		/// </summary>
		/// <returns>Возвращает true, если ссылка является пустой.</returns>
		public override bool Пустая() {
			return String.IsNullOrEmpty(this.name);
		}

		/// <summary>
		/// Строковое представление ссылки
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return this.Метаданные().Синоним();
		}
	}
}
