using System;
using Gtk;
using AggrocubeClient.UI;

namespace AggrocubeClient
{
	class AggrocubeClient
	{
		public AggrocubeClient() {
			Application.Init();
			
			Console.WriteLine("Started Aggrocube " + DateTime.Now);
			MenuWindow menuWindow = new MenuWindow();
			menuWindow.Show();
			
			Application.Run ();
		}
		
		public static void Main (string[] args)
		{	
			new AggrocubeClient();
		}
		
	}
	
}

