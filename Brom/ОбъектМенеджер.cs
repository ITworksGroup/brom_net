using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ITworks.Brom {
	public abstract class ОбъектМенеджер : МодульМенеджер {
		public ОбъектМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКоллекции, ТипКоллекции типКоллекции) : base(bromClient, метаданныеКоллекции) {
			this.типКоллекции = типКоллекции;
		}

		protected ТипКоллекции типКоллекции;


		public Селектор СоздатьСелектор() {
			Селектор селектор = new Селектор(this.bromClient);
			селектор.УстановитьКоллекцию(this.типКоллекции, this.moduleMetadata.Имя());
			return селектор;
		}

		public Ссылка ПолучитьСсылку(Guid идентификатор) {
			return Ссылка.СоздатьСсылку(this.bromClient, this.типКоллекции, this.moduleMetadata.Имя(), идентификатор);
		}
		public Ссылка ПолучитьСсылку(string идентификатор) {
			return Ссылка.СоздатьСсылку(this.bromClient, this.типКоллекции, this.moduleMetadata.Имя(), идентификатор);
		}

		public Ссылка ПустаяСсылка() {
			return Ссылка.СоздатьСсылку(this.bromClient, this.типКоллекции, this.moduleMetadata.Имя());
		}

		protected КонтекстОбъекта СоздатьОбъект() {
			return КонтекстОбъекта.ПолучитьКонтекстОбъекта(
				Ссылка.СоздатьСсылку(this.bromClient, this.типКоллекции, this.moduleMetadata.Имя()) as ОбъектСсылка
			);
		}

		#region DynamicObject
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			result = null;
			Ссылка resultRef = null;
			var predefined = (this.moduleMetadata as МетаданныеОбъект).Предопределенные;
			bool checkResult = predefined != null ? predefined.TryGetValue(binder.Name, out resultRef) : false;
			result = resultRef;
			return checkResult;
		}
		public override IEnumerable<string> GetDynamicMemberNames() {
			var predefined = ((МетаданныеОбъект)this.moduleMetadata).Предопределенные;
			return predefined?.Keys ?? new string[0];
		}
		#endregion
	}
}
