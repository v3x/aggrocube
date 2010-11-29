using System;

namespace AggrocubeClient.UI
{
	public partial class ServerWindow : Gtk.Window
	{
		protected virtual void OnCloseButtonClicked (object sender, System.EventArgs e)
		{
			this.Destroy();
		}
		
		public ServerWindow() : base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}

