using System;
namespace AggrocubeClient.UI
{
	public partial class MenuWindow : Gtk.Window
	{
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

