using System;
using App.Loner.Utils;

namespace App.Loner
{
	public class Core
	{
		public static Logcat log { get; set; }

		public static void Boot()
		{
			Console.WriteLine("Loner is running...");

			log = new Logcat();
		}

	}
}
