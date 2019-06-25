using ITworks.Brom.Types;
using ITworks.Brom;
using System;
using Xunit;

namespace BromUnitTests {
	public class ������������������� : �������������� {

        [Fact]
        public void ��������������()
        {
			object ��������� = this.����������.���������(@"
				��������� = 100 + 12.57;
			");
			Assert.IsType<decimal>(���������);
			Assert.Equal((decimal)112.57, (decimal)���������);

			��������� = this.����������.���������(@"
					��������� = ��������.� + ��������.�;
				", 
				new ���������("�, �", 10, 147.99)
			);
			Assert.IsType<decimal>(���������);
			Assert.Equal((decimal)157.99, (decimal)���������);
		}

		[Fact]
		public void ��������������������������������() {
			object ��������� = this.������.����("������!!!");
			Assert.IsType<string>(���������);
			Assert.Equal("������!!!", (string)���������);

			��������� = this.������.������(new DateTime(1990, 1, 12), "��=dd.MM.yyyy");
			Assert.IsType<string>(���������);
			Assert.Equal("12.01.1990", (string)���������);

			��������� = this.������.�������������(1234567, "�=ru_RU");
			Assert.IsType<string>(���������);
			Assert.Equal("���� ������� ������ �������� ������ ������ ������� ���������� ����  00 ", (string)���������);
		}

		[Fact]
		public void ������������������������() {
			Assert.IsType<�����������>(this.������.brom_����������_��);

			object ��������� = this.������.brom_����������_��.�������������("����������.������������");
			Assert.True((bool)���������);

			��������� = this.������.brom_����������_��.�����������("����������.������������");
			Assert.False((bool)���������);
		}
	}
}
