using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System.Linq;
using Xunit;

namespace BromUnitTests {
	public class �������������� : �������������� {

		private void �������������������() {
			Assert.NotNull(this.������.����������.�����������);
			Assert.NotNull(this.������.����������.�����������.������������);
			Assert.IsType<����������������>(this.������.�����������.������������.������������());

			Assert.NotNull(this.������.����������.���������);
			Assert.NotNull(this.������.����������.���������.������������);
			Assert.IsType<��������������>(this.������.���������.������������.������������());

			Assert.NotNull(this.������.����������.������������);
			Assert.NotNull(this.������.����������.������������.������������������);
			Assert.IsType<������������������>(this.������.������������.������������������.�������);

			Assert.Equal(this.����������.����������.Count(), this.����������.����������.GetDynamicMemberNames().Count());
		}

        [Fact]
        public void �������������������������()
        {
			this.������.�������������������();

			this.�������������������();
		}
		[Fact]
		public void ���������������������������������() {
			��������������������� ��� = new ���������������������(@"F:\Development\C# Projects\Brom\Cache\ShortCache");
			���.��������();

			this.������.�������������������(���);

			this.�������������������();
		}
		[Fact]
		public void �����������������������������������() {
			��������������������� ��� = new ���������������������(@"F:\Development\C# Projects\Brom\Cache\LongCache");

			this.������.�������������������(���);

			this.�������������������();
		}
	}
}
