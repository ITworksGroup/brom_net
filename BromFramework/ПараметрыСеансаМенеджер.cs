using ITworks.Brom.Metadata;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль коллекции параметров сеанса.
	/// </summary>
	public class ПараметрыСеансаМенеджер : КоллекцияМенеджер {
		internal ПараметрыСеансаМенеджер(БромКлиент bromClient) : base(bromClient, bromClient.Метаданные.Найти("ПараметрыСеанса")) {			
		}

		private bool TryGetMemberCommon(string fieldName, out object result) {
			УзелМетаданных метаданные = this.moduleMetadata.Найти(fieldName);
			if (метаданные != null) {
				result = this.bromClient.ПолучитьЗначениеПараметраСеанса(метаданные.Имя());
				return true;
			}

			result = null;
			return false;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon(((string)indexes[0]), out result);
		}

		
	}
}
