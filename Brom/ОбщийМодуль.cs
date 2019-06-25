using ITworks.Brom.Metadata;
using System.Dynamic;

namespace ITworks.Brom {
	/// <summary>
	/// Общий модуль.
	/// </summary>
	public class ОбщийМодуль : ПрограммныйМодуль {
		internal ОбщийМодуль(БромКлиент клиент, УзелМетаданных метаданныеМодуля):base(клиент, метаданныеМодуля) {
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
			result = this.bromClient.ВызватьМетод(this.moduleMetadata.Имя(), binder.Name, args);

			return true;
		}

		public override string ToString() {
			return string.Format("{0}.{1}", base.ToString(), this.moduleMetadata.Имя());
		}
	}
}
