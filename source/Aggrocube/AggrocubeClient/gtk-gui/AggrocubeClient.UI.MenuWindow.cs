
// This file has been generated by the GUI designer. Do not modify.
namespace AggrocubeClient.UI
{
	public partial class MenuWindow
	{
		private global::Gtk.VBox menuBox;

		private global::Gtk.Image menuImage;

		private global::Gtk.VButtonBox buttonBox;

		private global::Gtk.Button buttonSingle;

		private global::Gtk.Button buttonMulti;

		private global::Gtk.Button buttonSettings;

		private global::Gtk.Label versionLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget AggrocubeClient.UI.MenuWindow
			this.Name = "AggrocubeClient.UI.MenuWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Aggrocube");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-media-stop", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child AggrocubeClient.UI.MenuWindow.Gtk.Container+ContainerChild
			this.menuBox = new global::Gtk.VBox ();
			this.menuBox.Name = "menuBox";
			this.menuBox.Spacing = 6;
			// Container child menuBox.Gtk.Box+BoxChild
			this.menuImage = new global::Gtk.Image ();
			this.menuImage.Name = "menuImage";
			this.menuImage.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("AggrocubeClient.aggrocube.png");
			this.menuBox.Add (this.menuImage);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.menuBox[this.menuImage]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child menuBox.Gtk.Box+BoxChild
			this.buttonBox = new global::Gtk.VButtonBox ();
			this.buttonBox.Name = "buttonBox";
			this.buttonBox.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child buttonBox.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSingle = new global::Gtk.Button ();
			this.buttonSingle.WidthRequest = 200;
			this.buttonSingle.CanFocus = true;
			this.buttonSingle.Name = "buttonSingle";
			this.buttonSingle.UseUnderline = true;
			this.buttonSingle.Label = global::Mono.Unix.Catalog.GetString ("Single-player");
			this.buttonBox.Add (this.buttonSingle);
			global::Gtk.ButtonBox.ButtonBoxChild w2 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.buttonBox[this.buttonSingle]));
			w2.Expand = false;
			w2.Fill = false;
			// Container child buttonBox.Gtk.ButtonBox+ButtonBoxChild
			this.buttonMulti = new global::Gtk.Button ();
			this.buttonMulti.CanFocus = true;
			this.buttonMulti.Name = "buttonMulti";
			this.buttonMulti.UseUnderline = true;
			this.buttonMulti.Label = global::Mono.Unix.Catalog.GetString ("Multiplayer");
			this.buttonBox.Add (this.buttonMulti);
			global::Gtk.ButtonBox.ButtonBoxChild w3 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.buttonBox[this.buttonMulti]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child buttonBox.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSettings = new global::Gtk.Button ();
			this.buttonSettings.CanFocus = true;
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.UseUnderline = true;
			this.buttonSettings.Label = global::Mono.Unix.Catalog.GetString ("Settings");
			this.buttonBox.Add (this.buttonSettings);
			global::Gtk.ButtonBox.ButtonBoxChild w4 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.buttonBox[this.buttonSettings]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.menuBox.Add (this.buttonBox);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.menuBox[this.buttonBox]));
			w5.Position = 1;
			// Container child menuBox.Gtk.Box+BoxChild
			this.versionLabel = new global::Gtk.Label ();
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Version 0.0.1");
			this.menuBox.Add (this.versionLabel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.menuBox[this.versionLabel]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			w6.Padding = ((uint)(5));
			this.Add (this.menuBox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 352;
			this.DefaultHeight = 246;
			this.Show ();
			this.buttonSingle.Clicked += new global::System.EventHandler (this.OnButtonSingleClicked);
			this.buttonMulti.Clicked += new global::System.EventHandler (this.OnButtonMultiClicked);
			this.buttonSettings.Clicked += new global::System.EventHandler (this.OnButtonSettingsClicked);
		}
	}
}
