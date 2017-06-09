using System;
using System.Text;

namespace App.Loner.Utils
{

	public abstract class Logcat
	{

		public StringBuilder Info { get; set; }
		public StringBuilder Debug { get; set; }
		public StringBuilder Error { get; set; }

		public Logcat()
		{
			Info = new StringBuilder();
			Debug = new StringBuilder();
			Error = new StringBuilder();
		}

		public void i(string message)
		{
			Info.AppendLine(message);
			Console.WriteLine(message);
		}

		public void d(string message)
		{
			Debug.AppendLine(message);
			Console.WriteLine(message);
		}

		public void e(string message)
		{
			Error.AppendLine(message);
			Console.WriteLine(message);

		}

	}
}
