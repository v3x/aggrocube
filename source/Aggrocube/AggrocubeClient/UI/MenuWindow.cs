using System;
using System.Threading;

namespace AggrocubeClient.UI
{
	public partial class MenuWindow : Gtk.Window
	{
		protected virtual void OnButtonSingleClicked (object sender, System.EventArgs e)
		{
			Thread renderThread = new Thread(new ThreadStart(RenderWindow.Create));
			renderThread.Start();
			this.Visible = false;
		}
		
		protected virtual void OnButtonMultiClicked (object sender, System.EventArgs e)
		{
			ServerWindow serverWindow = new ServerWindow();
            serverWindow.Show();
		}
		
		protected virtual void OnButtonSettingsClicked (object sender, System.EventArgs e)
		{
			SettingsWindow settingsWindow = new SettingsWindow();
			settingsWindow.Show();
		}
		
		public MenuWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}

