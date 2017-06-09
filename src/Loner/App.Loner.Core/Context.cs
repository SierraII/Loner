using System;
using App.Loner.Utils;

namespace App.Loner.Core
{
	public class Context
	{
		
		public static Logcat log { get; set; }

		static Context()
		{
			log = new Logcat();
		}

	}
}
