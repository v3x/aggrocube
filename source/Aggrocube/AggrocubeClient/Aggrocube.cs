using System;
using Gtk;
using AggrocubeClient.UI;
using AggrocubeCommon.Logging;

namespace AggrocubeClient
{
	class AggrocubeClient
	{
		private OperatingSystem os;
		private PlatformID platform_id;
		
		public AggrocubeClient() 
		{
			Application.Init();
			
			os = Environment.OSVersion;
			platform_id = os.Platform;
			
			Log.WriteConsole("Started Aggrocube on " + platform_id);
			MenuWindow menuWindow = new MenuWindow();
			menuWindow.Show();
			
			Application.Run();
		}
		
		public static void Main (string[] args)
		{	
			new AggrocubeClient();
		}
	}
}

