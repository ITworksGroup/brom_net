using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System.Linq;
using Xunit;

namespace BromUnitTests {
	public class ћетаданные“ест : Ѕром лиент“ест {

		private void ѕроверитьћетаданные() {
			Assert.NotNull(this. лиент.ћетаданные.—правочники);
			Assert.NotNull(this. лиент.ћетаданные.—правочники.Ќоменклатура);
			Assert.IsType<—правочник—сылка>(this. лиент.—правочники.Ќоменклатура.ѕуста€—сылка());

			Assert.NotNull(this. лиент.ћетаданные.ƒокументы);
			Assert.NotNull(this. лиент.ћетаданные.ƒокументы.«аказ лиента);
			Assert.IsType<ƒокумент—сылка>(this. лиент.ƒокументы.«аказ лиента.ѕуста€—сылка());

			Assert.NotNull(this. лиент.ћетаданные.ѕеречислени€);
			Assert.NotNull(this. лиент.ћетаданные.ѕеречислени€.ѕол‘изическогоЋица);
			Assert.IsType<ѕеречисление—сылка>(this. лиент.ѕеречислени€.ѕол‘изическогоЋица.∆енский);

			Assert.Equal(this.Ѕром лиент.ћетаданные.Count(), this.Ѕром лиент.ћетаданные.GetDynamicMemberNames().Count());
		}

        [Fact]
        public void «агрузкаћетаданныхЅез еша()
        {
			this. лиент.«агрузитьћетаданные();

			this.ѕроверитьћетаданные();
		}
		[Fact]
		public void «агрузкаћетаданных—ќчищенным ешем() {
			‘айловый ешћетаданных кеш = new ‘айловый ешћетаданных(@"F:\Development\C# Projects\Brom\Cache\ShortCache");
			кеш.ќчистить();

			this. лиент.«агрузитьћетаданные(кеш);

			this.ѕроверитьћетаданные();
		}
		[Fact]
		public void «агрузкаћетаданных—«аполненным ешем() {
			‘айловый ешћетаданных кеш = new ‘айловый ешћетаданных(@"F:\Development\C# Projects\Brom\Cache\LongCache");

			this. лиент.«агрузитьћетаданные(кеш);

			this.ѕроверитьћетаданные();
		}
	}
}
