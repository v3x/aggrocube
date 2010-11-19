using System;

namespace AggrocubeClient.UI
{
	public partial class SettingsWindow : Gtk.Window
	{
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
		
		protected virtual void OnApplyButtonClicked (object sender, System.EventArgs e)
		{
			// TODO: Actually save settings.
			this.Destroy();
		}
		
		public SettingsWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}		
	}
}

