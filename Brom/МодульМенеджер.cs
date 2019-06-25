using ITworks.Brom.Metadata;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Модуль менеджера.
	/// </summary>
	public class МодульМенеджер : ПрограммныйМодуль {
		internal МодульМенеджер(БромКлиент bromClient, УзелМетаданных метаданныеКонстанты) : base(bromClient, метаданныеКонстанты) { }

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
			result = this.bromClient.ВызватьМетод(this.moduleMetadata.Путь(), binder.Name, args);
			return true;
		}

		public override string ToString() {
			return string.Format("{0}.{1}", base.ToString(), this.moduleMetadata.Имя());
		}
	}
}
