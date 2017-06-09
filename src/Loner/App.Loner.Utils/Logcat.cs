using System;
using System.IO;
using System.Text;

namespace App.Loner.Utils
{
	public class Logcat
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

		// write to file
		public void i(string message)
		{

			message = getTimestamp() + " info: " + message;

			Info.AppendLine(message);

            writeToFile("logs.log", message);

			Console.WriteLine(message);

		}

		// don't write to file
		public void d(string message)
		{

			message = getTimestamp() + " debug: " + message;

			Debug.AppendLine(message);

			Console.WriteLine(message);

		}

		// log out to error file
		public void e(string message)
		{

			message = getTimestamp() + " error: " + message;

			Error.AppendLine(message);

			writeToFile("logs.log", message);
            writeToFile("error.log", message);

			Console.WriteLine(message);

		}

		private void writeToFile(string filename, string message)
		{
			using (StreamWriter file = new StreamWriter(@filename, true))
			{
				file.WriteLine(message);
			}
		}

		private string getTimestamp()
		{
			return DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss ffff");
		}

	}
}
