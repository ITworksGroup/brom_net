using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ITworks.Brom.Types {
    public class КолонкаКоллекцииЗначений {
		internal КолонкаКоллекцииЗначений(string имя, string заголовок = null) {
			if (!КолонкаКоллекцииЗначений.IsPropertyNameValid(имя)) {
				throw new ArgumentException("Недопустимое имя колонки.", "имя");
			}

			this.name = имя;
			this.title = String.IsNullOrEmpty(заголовок) ? имя : заголовок;
		} 

		private string name;
		private string title;

		static КолонкаКоллекцииЗначений() {
			КолонкаКоллекцииЗначений.regex = new Regex(@"[A-Za-zА-Яа-я_]{1}[A-Za-zА-Яа-я_0-9]*");
		}
		private static bool IsPropertyNameValid(string name) {
			return КолонкаКоллекцииЗначений.regex.Match(name).Value == name;
		}

		private static Regex regex;

		public string Имя {
			get { return this.name; }
			set {
				if (!КолонкаКоллекцииЗначений.IsPropertyNameValid(value)) {
					throw new Exception("Недопустимое имя колонки.");
				}

				var e = new { oldName = this.name, newName = value };
				this.onStartRename?.Invoke(this, e);
				this.name = value;
				this.onRename?.Invoke(this, e);
			}
		}

		private event EventHandler<object> onStartRename;
		private event EventHandler<object> onRename;

		internal event EventHandler<object> OnRename {
			add {
				this.onRename += value;
			}
			remove {
				this.onRename -= value;
			}
		}
		internal event EventHandler<object> OnStartRename {
			add {
				this.onStartRename += value;
			}
			remove {
				this.onStartRename -= value;
			}
		}

		public override string ToString() {
			return this.name;
		}
	}
}
