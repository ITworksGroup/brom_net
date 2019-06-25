using System.IO;
using System.Text;

namespace ITworks.Brom.Metadata {
	public class ФайловыйКешМетаданных : ИКешМетаданных {
		public ФайловыйКешМетаданных(string адресДиректории) {
			this.rootDirectoryPath = адресДиректории;
			this.dataDirectoryPath = Path.Combine(this.rootDirectoryPath, "data");
		}

		private readonly string rootDirectoryPath;
		private readonly string dataDirectoryPath;

		private string ПолучитьХэшКлюча(string ключ) {
			using (var provider = System.Security.Cryptography.MD5.Create()) {
				StringBuilder builder = new StringBuilder();

				foreach (byte tempByte in provider.ComputeHash(Encoding.UTF8.GetBytes(ключ.ToLower()))) {
					builder.Append(tempByte.ToString("x2").ToLower());
				}	

				return builder.ToString();
			}
		}

		public string АдресДиректории {
			get { return this.rootDirectoryPath; }
		}

		public bool ПопыткаПолучитьЗначение(string key, out string value) {
			string hash = this.ПолучитьХэшКлюча(key);
			string path = Path.Combine(this.dataDirectoryPath, hash);

			if (File.Exists(path)) {
				value = File.ReadAllText(path, Encoding.UTF8);
				return true;
			}

			value = null;
			return false;
		}

		public void УстановитьЗначение(string key, string value) {
			Directory.CreateDirectory(this.dataDirectoryPath);

			string hash = this.ПолучитьХэшКлюча(key);
			string path = Path.Combine(this.dataDirectoryPath, hash);
			File.WriteAllText(path, value, Encoding.UTF8);
		}

		public void Очистить() {
			if (Directory.Exists(this.dataDirectoryPath)) {
				Directory.Delete(this.dataDirectoryPath, true);
			}
		}

		public bool СодержитКлюч(string key) {
			string hash = this.ПолучитьХэшКлюча(key);
			string path = Path.Combine(this.dataDirectoryPath, hash);
			return File.Exists(path);
		}
	}
}
