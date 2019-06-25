using ITworks.Brom.Metadata;
using System;

namespace ITworks.Brom {
	/// <summary>
	/// Контекст табличной части.
	/// </summary>
	public class ТабличнаяЧастьКонтекст : ТабличнаяЧасть {
		internal ТабличнаяЧастьКонтекст(МетаданныеТабличнаяЧасть метаданные) : base(метаданные) { }
		internal ТабличнаяЧастьКонтекст(МетаданныеТабличнаяЧасть метаданные, int размерКоллекции) : base(метаданные, размерКоллекции) {	}

		private bool isModified;

		private event EventHandler<string> onModifiedChanged;

		internal event EventHandler<string> OnModifiedChanged {
			add { this.onModifiedChanged += value; }
			remove { this.onModifiedChanged -= value; }
		}

		internal void SetIsModified(bool value) {
			if (!this.isModified && value) {
				this.onModifiedChanged?.Invoke(this, this.Метаданные().Имя());
			}
			this.isModified = value;
		}

		/// <summary>
		/// Добавляет строку табличной части и возращает ее в качестве результата.
		/// </summary>
		/// <returns>Возвращает строку табличной части, которая была добавлена.</returns>
		public СтрокаТабличнойЧасти Добавить() {
			СтрокаТабличнойЧасти стр =  this.ДобавитьСтроку();
			this.SetIsModified(true);
			return стр;
		}

		/// <summary>
		/// Удаляет строку табличной части.
		/// </summary>
		/// <param name="строка">Строка табличной части.</param>
		public void Удалить(СтрокаТабличнойЧасти строка) {
			this.УдалитьСтроку(строка);
			this.SetIsModified(true);
		}

		/// <summary>
		/// Полностью очищает табличную часть.
		/// </summary>
		public void Очистить() {
			this.rows.Clear();
			this.SetIsModified(true);
		}
	}
}
