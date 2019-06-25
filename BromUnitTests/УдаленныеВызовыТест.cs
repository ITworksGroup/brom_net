using ITworks.Brom.Types;
using ITworks.Brom;
using System;
using Xunit;

namespace BromUnitTests {
	public class УдаленныеВызовыТест : БромКлиентТест {

        [Fact]
        public void ВыполнениеКода()
        {
			object результат = this.БромКлиент.Выполнить(@"
				Результат = 100 + 12.57;
			");
			Assert.IsType<decimal>(результат);
			Assert.Equal((decimal)112.57, (decimal)результат);

			результат = this.БромКлиент.Выполнить(@"
					Результат = Параметр.А + Параметр.Б;
				", 
				new Структура("А, Б", 10, 147.99)
			);
			Assert.IsType<decimal>(результат);
			Assert.Equal((decimal)157.99, (decimal)результат);
		}

		[Fact]
		public void ВызовМетодовГлобальногоКонтекста() {
			object результат = this.Клиент.ВРег("Привет!!!");
			Assert.IsType<string>(результат);
			Assert.Equal("ПРИВЕТ!!!", (string)результат);

			результат = this.Клиент.Формат(new DateTime(1990, 1, 12), "ДФ=dd.MM.yyyy");
			Assert.IsType<string>(результат);
			Assert.Equal("12.01.1990", (string)результат);

			результат = this.Клиент.ЧислоПрописью(1234567, "Л=ru_RU");
			Assert.IsType<string>(результат);
			Assert.Equal("Один миллион двести тридцать четыре тысячи пятьсот шестьдесят семь  00 ", (string)результат);
		}

		[Fact]
		public void ВызовМетодовОбщихМодулей() {
			Assert.IsType<ОбщийМодуль>(this.Клиент.brom_Метаданные_ПИ);

			object результат = this.Клиент.brom_Метаданные_ПИ.ЭтоСправочник("Справочник.Номенклатура");
			Assert.True((bool)результат);

			результат = this.Клиент.brom_Метаданные_ПИ.ЭтоДокумент("Справочник.Номенклатура");
			Assert.False((bool)результат);
		}
	}
}
