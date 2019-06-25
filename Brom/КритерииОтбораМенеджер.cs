﻿using ITworks.Brom.Metadata;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера коллекции критериев отбора.
	/// </summary>
	public class КритерииОтбораМенеджер : КоллекцияМенеджер {
		internal КритерииОтбораМенеджер(БромКлиент bromClient) : base(bromClient, bromClient.Метаданные.Найти("КритерииОтбора")) {		
		}

		private bool TryGetMemberCommon(string fieldName, out object result) {
			УзелМетаданных метаданные = this.moduleMetadata.Найти(fieldName);
			if (метаданные != null) {
				result = new КритерийОтбораМенеджер(this.bromClient, метаданные);
				return true;
			}

			result = null;
			return false;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			return this.TryGetMemberCommon(binder.Name, out result);
		}
		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			return this.TryGetMemberCommon((string)indexes[0], out result);
		}
	}
}
