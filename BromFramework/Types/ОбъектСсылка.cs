using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ITworks.Brom.Types {
	public abstract class ОбъектСсылка : Ссылка, IEquatable<ОбъектСсылка> {
		internal ОбъектСсылка(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци, Guid guid) : base(клиент, типКоллекции, имяКоллекци) {
			this.guid = guid;
		}
		internal ОбъектСсылка(БромКлиент клиент, string полноеИмяТипа, Guid guid) : base(клиент, полноеИмяТипа) {
			this.guid = guid;
		}
		internal ОбъектСсылка(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци, string guid) : this(клиент, типКоллекции, имяКоллекци, new Guid(guid)) { }
		internal ОбъектСсылка(БромКлиент клиент, ТипКоллекции типКоллекции, string имяКоллекци) : this(клиент, типКоллекции, имяКоллекци, new Guid()) { }

		private readonly Guid guid;

		public Guid УникальныйИдентификатор() {
			return this.guid;
		}

		public override bool Пустая() {
			return this.guid == Guid.Empty;
		}

		public КонтекстОбъекта ПолучитьОбъект() {
			if (this.Пустая()) {
				throw new Exception("Невозможно получить объект пустой ссылки. Воспользуйтесь методом \"СоздатьОбъект\" модуля менеджера коллекции.");
			}

			КонтекстОбъекта контекст = КонтекстОбъекта.ПолучитьКонтекстОбъекта(this);
			контекст.ЗагрузитьДанные();
			return контекст;
		}

		public override string ToString() {
			string представление = this.bromClient.Контекст().ПолучитьПредставлениеОбъекта(this);
			return !String.IsNullOrWhiteSpace(представление) ? представление : String.Format("{0}: ({1})", this.ПолноеИмяТипа(), this.guid);
		}

		public override bool Equals(object obj) {
			return this.Equals(obj as ОбъектСсылка);
		}

		public bool Equals(ОбъектСсылка other) {
			return	other != null &&
					this.bromClient.Equals(other.bromClient) &&
					this.guid.Equals(other.guid) &&
					this.ИмяКоллекции().Equals(other.ИмяКоллекции()) &&
					this.ТипКоллекции().Equals(other.ТипКоллекции());
		}

		public override int GetHashCode() {
			var hashCode = -977682019;
			hashCode = hashCode * -1521134295 + EqualityComparer<БромКлиент>.Default.GetHashCode(this.Клиент());
			hashCode = hashCode * -1521134295 + EqualityComparer<ТипКоллекции>.Default.GetHashCode(this.ТипКоллекции());
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.ИмяКоллекции());
			hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(this.УникальныйИдентификатор());
			return hashCode;
		}
		
		public static bool operator ==(ОбъектСсылка ссылка1, ОбъектСсылка ссылка2) {
			if (Object.ReferenceEquals(ссылка1, null)) {
				return Object.ReferenceEquals(ссылка2, null);
			}
			return ссылка1.Equals(ссылка2);
		}

		public static bool operator !=(ОбъектСсылка ссылка1, ОбъектСсылка ссылка2) {
			return !(ссылка1 == ссылка2);
		}

		#region DynamicObject
		private bool TryGetMemberCommon(string fieldName, out object result) {
			return this.bromClient.Контекст().ПопыткаПолучитьЗначение(this, fieldName, out result);
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon(indexes[0].ToString(), out result);
		}
		public override IEnumerable<string> GetDynamicMemberNames() {
			IEnumerable<string> реквизиты = ((dynamic)this.Метаданные()).Реквизиты.GetDynamicMemberNames();
			IEnumerable<string> табЧасти = ((dynamic)this.Метаданные()).ТабличныеЧасти.GetDynamicMemberNames();
			return реквизиты.Concat(табЧасти);
		}

		#endregion

	}
}
