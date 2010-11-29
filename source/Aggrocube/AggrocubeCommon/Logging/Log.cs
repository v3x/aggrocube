using System;
namespace AggrocubeCommon.Logging
{
	public class Log
	{		
		public static void WriteConsole(string message)
		{
			System.Console.WriteLine("[" + DateTime.Now + "] " + message);
		}
	}
}

