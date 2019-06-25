using ITworks.Brom.Metadata;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ITworks.Brom.Types {
	public abstract class Ссылка : DynamicObject, IEquatable<Ссылка> {
		public Ссылка(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекции) {
			this.bromClient = клиент;
			this.collectionType = типКоллекции;
			this.collectionName = имяКоллекции;
		}
		public Ссылка(БромКлиент клиент, string полноеИмяТипа) {
			this.bromClient = клиент;

			string[] фрагментыИмени = полноеИмяТипа.Trim().Split(".");
			if (фрагментыИмени.Length != 2) {
				throw new ArgumentException("Переданный параметр \"полноеИмяТип\" не соответствует шаблону {ТипКоллекции.ИмяКоллекции}", "полноеИмяТипа");
			}

			this.collectionType = Enum.Parse<ТипКоллекции>(фрагментыИмени[0], true);
			this.collectionName = фрагментыИмени[1];
		}

		protected readonly БромКлиент bromClient;
		protected readonly ТипКоллекции collectionType;
		protected readonly string collectionName;

		public ТипКоллекции ТипКоллекции() {
			return this.collectionType;
		}
		public string ИмяКоллекции() {
			return this.collectionName;
		}
		public БромКлиент Клиент() {
			return this.bromClient;
		}

		public string ПолноеИмяТипа() {
			return this.collectionType.ToString() + "." + this.collectionName;
		}
		public УзелМетаданных Метаданные() {
			УзелМетаданных метаданные = null;
			this.bromClient.Метаданные.ПопыткаПолучить(this.ПолноеИмяТипа(), out метаданные);
			return метаданные;
		}

		public abstract bool Пустая();

		public static Ссылка СоздатьСсылку(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци, Guid указатель) {
			return клиент.Контекст().ПолучитьОбъектСсылку(String.Format("{0}.{1}", типКоллекции, имяКоллекци), указатель);
		}
		public static Ссылка СоздатьСсылку(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци, string указатель) {
			if (типКоллекции == Types.ТипКоллекции.Перечисление) {
				return клиент.Контекст().ПолучитьПеречислениеСсылку(String.Format("{0}.{1}", типКоллекции, имяКоллекци), указатель);
			}
			else {
				return клиент.Контекст().ПолучитьОбъектСсылку(String.Format("{0}.{1}", типКоллекции, имяКоллекци), new Guid(указатель));
			}
		}
		public static Ссылка СоздатьСсылку(БромКлиент клиент, string полноеИмяТипа, Guid указатель) {
			return клиент.Контекст().ПолучитьОбъектСсылку(полноеИмяТипа, указатель);
		}
		public static Ссылка СоздатьСсылку(БромКлиент клиент, string полноеИмяТипа, string указатель) {
			string[] фрагментыИмени = полноеИмяТипа.Trim().Split(".");
			if (фрагментыИмени.Length != 2) {
				throw new ArgumentException("Переданный параметр \"полноеИмяТип\" не соответствует шаблону {ТипКоллекции.ИмяКоллекции}", "полноеИмяТипа");
			}

			ТипКоллекции типКоллекции = Enum.Parse<ТипКоллекции>(фрагментыИмени[0], true);
			string имяКоллекции = фрагментыИмени[1];

			if (типКоллекции == Types.ТипКоллекции.Перечисление) {
				return клиент.Контекст().ПолучитьПеречислениеСсылку(полноеИмяТипа, указатель);
			}
			else {
				return клиент.Контекст().ПолучитьОбъектСсылку(полноеИмяТипа, new Guid(указатель));
			}
		}
		public static Ссылка СоздатьСсылку(БромКлиент клиент, string полноеИмяТипа) {
			string[] фрагментыИмени = полноеИмяТипа.Trim().Split(".");
			if (фрагментыИмени.Length != 2) {
				throw new ArgumentException("Переданный параметр \"полноеИмяТип\" не соответствует шаблону {ТипКоллекции.ИмяКоллекции}", "полноеИмяТипа");
			}

			ТипКоллекции типКоллекции = Enum.Parse<ТипКоллекции>(фрагментыИмени[0], true);
			string имяКоллекции = фрагментыИмени[1];

			return СоздатьСсылку(клиент, типКоллекции, имяКоллекции);
		}
		public static Ссылка СоздатьСсылку(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци) {
			if (типКоллекции == Types.ТипКоллекции.Перечисление) {
				return клиент.Контекст().ПолучитьПеречислениеСсылку(String.Format("{0}.{1}", типКоллекции, имяКоллекци), "");
			}
			else {
				return клиент.Контекст().ПолучитьОбъектСсылку(String.Format("{0}.{1}", типКоллекции, имяКоллекци), new Guid());
			}
		}

		public override bool Equals(object obj) {
			return this.Equals(obj as Ссылка);
		}
		public bool Equals(Ссылка other) {
			return other != null &&
				   this.GetHashCode() == other.GetHashCode();
		}
		public override int GetHashCode() {
			var hashCode = -977682019;
			hashCode = hashCode * -1521134295 + EqualityComparer<БромКлиент>.Default.GetHashCode(this.bromClient);
			hashCode = hashCode * -1521134295 + this.collectionType.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.collectionName);
			return hashCode;
		}
		public static bool operator ==(Ссылка ссылка1, Ссылка ссылка2) {
			if (Object.ReferenceEquals(ссылка1, null)) {
				return Object.ReferenceEquals(ссылка2, null);
			}
			return ссылка1.Equals(ссылка2);
		}
		public static bool operator !=(Ссылка ссылка1, Ссылка ссылка2) {
			return !(ссылка1 == ссылка2);
		}

		~Ссылка() {
			try {
				this.bromClient.Контекст().УничтожитьСсылку(this);
			}
			catch { }
		}
	}
}
