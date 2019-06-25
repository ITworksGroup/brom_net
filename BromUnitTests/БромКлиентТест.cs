using ITworks.Brom;
using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System.Linq;
using Xunit;

namespace BromUnitTests {
	public abstract class Ѕром лиент“ест {
		public Ѕром лиент“ест() {
			this.клиент = new Ѕром лиент(@"
				публикаци€		= http://136.243.67.133/brom_ut; 
				пользователь	= Brom; 
				пароль			= brompass
			");

			//‘айловый ешћетаданных кеш = new ‘айловый ешћетаданных(@"F:\Development\C# Projects\Brom\Cache\LongCache");
			//this.клиент.«агрузитьћетаданные(кеш);
		}

		private Ѕром лиент клиент;

		public dynamic  лиент {
			get { return клиент; }
		}
		public Ѕром лиент Ѕром лиент {
			get { return клиент; }
		}
	}
}
