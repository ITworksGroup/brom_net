using System;

namespace ITworks.Brom {
	/// <summary>
	/// Настройки автозагрузки контекстных данных объектов.
	/// </summary>
    public class АвтозагрузкаПолейОбъектов {
		/// <summary>
		/// Конструктор настроек.
		/// </summary>
		/// <param name="загружатьСтандартныеРеквизиты">Включает загрузку стандартных реквизитов.</param>
		/// <param name="загружатьПользовательскиеРеквизиты">Включает загрузку пользовательских реквизитов.</param>
		/// <param name="загружатьТабличныеЧасти">Включает загрузку табличных частей.</param>
		public АвтозагрузкаПолейОбъектов(bool загружатьСтандартныеРеквизиты, bool загружатьПользовательскиеРеквизиты, bool загружатьТабличныеЧасти) {
			this.loadDefaultAttributes = загружатьСтандартныеРеквизиты;
			this.loadCustomAttributes = загружатьПользовательскиеРеквизиты;
			this.loadTableSections = загружатьТабличныеЧасти;
		}
		/// <summary>
		/// Конструктор настроек.
		/// </summary>
		public АвтозагрузкаПолейОбъектов():this(false, false, false) { }

		private bool loadDefaultAttributes;
		private bool loadCustomAttributes;
		private bool loadTableSections;

		private event EventHandler changed;

		/// <summary>
		/// Событие при изменении настроек.
		/// </summary>
		public event EventHandler ПриИзменении {
			add { this.changed += value; }
			remove { this.changed -= value; }
		}

		/// <summary>
		/// Флаг включения автоматической загрузки стандартных реквизитов объектов.
		/// </summary>
		public bool ЗагружатьСтандартныеРеквизиты {
			get { return this.loadDefaultAttributes; }
			set {
				this.loadDefaultAttributes = value;
				this.changed?.Invoke(this, null);
			}
		}
		/// <summary>
		/// Флаг включения автоматической загрузки поользовательских реквизитов объектов.
		/// </summary>
		public bool ЗагружатьПользовательскиеРеквизиты {
			get { return this.loadCustomAttributes; }
			set {
				this.loadCustomAttributes = value;
				this.changed?.Invoke(this, null);
			}
		}
		/// <summary>
		/// Флаг включения автоматической загрузки табличных частей объектов.
		/// </summary>
		public bool ЗагружатьТабличныеЧасти {
			get { return this.loadTableSections; }
			set {
				this.loadTableSections = value;
				this.changed?.Invoke(this, null);
			}
		}

		/// <summary>
		/// Не загружать ничего.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов Ничего {
			get { return new АвтозагрузкаПолейОбъектов(false, false, false); }
		}
		/// <summary>
		/// Автоматически загружать все реквизиты и табличные части объектов.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов ВсеПоля {
			get { return new АвтозагрузкаПолейОбъектов(true, true, true); }
		}
		/// <summary>
		/// Автоматически загружать только стандартные реквизиты объектов.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов ТолькоСтандартныеРеквизиты {
			get { return new АвтозагрузкаПолейОбъектов(true, false, false); }
		}
		/// <summary>
		/// Автоматически загружать только пользовательские реквизиты объектов.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов ТолькоПользовательскиеРеквизиты {
			get { return new АвтозагрузкаПолейОбъектов(false, true, false); }
		}
		/// <summary>
		/// Автоматически загружать стандартные и пользовательские реквизиты объектов.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов ТолькоРеквизиты {
			get { return new АвтозагрузкаПолейОбъектов(true, true, false); }
		}
		/// <summary>
		/// Автоматически загружать только табличные части объектов.
		/// </summary>
		public static АвтозагрузкаПолейОбъектов ТолькоТабличныеЧасти {
			get { return new АвтозагрузкаПолейОбъектов(false, false, true); }
		}
	}
}
