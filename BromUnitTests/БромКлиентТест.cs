using ITworks.Brom;
using ITworks.Brom.Metadata;
using ITworks.Brom.Types;
using System.Linq;
using Xunit;

namespace BromUnitTests {
	public abstract class �������������� {
		public ��������������() {
			this.������ = new ����������(@"
				����������		= http://136.243.67.133/brom_ut; 
				������������	= Brom; 
				������			= brompass
			");

			//��������������������� ��� = new ���������������������(@"F:\Development\C# Projects\Brom\Cache\LongCache");
			//this.������.�������������������(���);
		}

		private ���������� ������;

		public dynamic ������ {
			get { return ������; }
		}
		public ���������� ���������� {
			get { return ������; }
		}
	}
}
