
// This file has been generated by the GUI designer. Do not modify.
namespace AggrocubeClient.UI
{
	public partial class SettingsWindow
	{
		private global::Gtk.Table settingsTable;

		private global::Gtk.HButtonBox saveBox;

		private global::Gtk.Button cancelButton;

		private global::Gtk.Button applyButton;

		private global::Gtk.Frame videoFrame;

		private global::Gtk.Alignment videoAlignment;

		private global::Gtk.Table videoTable;

		private global::Gtk.Button fullscreenButton;

		private global::Gtk.Label videoLabel;

		private global::Gtk.Frame volumeFrame;

		private global::Gtk.Alignment volumeAlignment;

		private global::Gtk.Table volumeTable;

		private global::Gtk.Label critterLabel;

		private global::Gtk.HScale CritterSlider;

		private global::Gtk.Label musicLabel;

		private global::Gtk.HScale musicSlider;

		private global::Gtk.Label soundLabel;

		private global::Gtk.HScale soundSlider;

		private global::Gtk.Label volumeLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget AggrocubeClient.UI.SettingsWindow
			this.Name = "AggrocubeClient.UI.SettingsWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Settings");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-properties", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(2));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.Resizable = false;
			this.AllowGrow = false;
			this.DestroyWithParent = true;
			this.Gravity = ((global::Gdk.Gravity)(5));
			// Container child AggrocubeClient.UI.SettingsWindow.Gtk.Container+ContainerChild
			this.settingsTable = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.settingsTable.WidthRequest = 500;
			this.settingsTable.Name = "settingsTable";
			this.settingsTable.RowSpacing = ((uint)(6));
			this.settingsTable.ColumnSpacing = ((uint)(6));
			// Container child settingsTable.Gtk.Table+TableChild
			this.saveBox = new global::Gtk.HButtonBox ();
			this.saveBox.Name = "saveBox";
			this.saveBox.Spacing = 5;
			this.saveBox.BorderWidth = ((uint)(5));
			this.saveBox.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child saveBox.Gtk.ButtonBox+ButtonBoxChild
			this.cancelButton = new global::Gtk.Button ();
			this.cancelButton.CanFocus = true;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseUnderline = true;
			// Container child cancelButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w2 = new global::Gtk.HBox ();
			w2.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			w2.Add (w3);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w5 = new global::Gtk.Label ();
			w5.LabelProp = global::Mono.Unix.Catalog.GetString ("Cancel");
			w5.UseUnderline = true;
			w2.Add (w5);
			w1.Add (w2);
			this.cancelButton.Add (w1);
			this.saveBox.Add (this.cancelButton);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.saveBox[this.cancelButton]));
			w9.Expand = false;
			w9.Fill = false;
			// Container child saveBox.Gtk.ButtonBox+ButtonBoxChild
			this.applyButton = new global::Gtk.Button ();
			this.applyButton.CanFocus = true;
			this.applyButton.Name = "applyButton";
			this.applyButton.UseUnderline = true;
			// Container child applyButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w10 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w11 = new global::Gtk.HBox ();
			w11.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w12 = new global::Gtk.Image ();
			w12.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w11.Add (w12);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w14 = new global::Gtk.Label ();
			w14.LabelProp = global::Mono.Unix.Catalog.GetString ("Apply");
			w14.UseUnderline = true;
			w11.Add (w14);
			w10.Add (w11);
			this.applyButton.Add (w10);
			this.saveBox.Add (this.applyButton);
			global::Gtk.ButtonBox.ButtonBoxChild w18 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.saveBox[this.applyButton]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.settingsTable.Add (this.saveBox);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.settingsTable[this.saveBox]));
			w19.TopAttach = ((uint)(2));
			w19.BottomAttach = ((uint)(3));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child settingsTable.Gtk.Table+TableChild
			this.videoFrame = new global::Gtk.Frame ();
			this.videoFrame.Name = "videoFrame";
			this.videoFrame.ShadowType = ((global::Gtk.ShadowType)(4));
			this.videoFrame.BorderWidth = ((uint)(5));
			// Container child videoFrame.Gtk.Container+ContainerChild
			this.videoAlignment = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.videoAlignment.Name = "videoAlignment";
			this.videoAlignment.LeftPadding = ((uint)(12));
			this.videoAlignment.BorderWidth = ((uint)(5));
			// Container child videoAlignment.Gtk.Container+ContainerChild
			this.videoTable = new global::Gtk.Table (((uint)(3)), ((uint)(1)), false);
			this.videoTable.Name = "videoTable";
			this.videoTable.RowSpacing = ((uint)(6));
			this.videoTable.ColumnSpacing = ((uint)(6));
			// Container child videoTable.Gtk.Table+TableChild
			this.fullscreenButton = new global::Gtk.Button ();
			this.fullscreenButton.CanFocus = true;
			this.fullscreenButton.Name = "fullscreenButton";
			this.fullscreenButton.UseUnderline = true;
			this.fullscreenButton.Label = global::Mono.Unix.Catalog.GetString ("Windowed");
			this.videoTable.Add (this.fullscreenButton);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.videoTable[this.fullscreenButton]));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			this.videoAlignment.Add (this.videoTable);
			this.videoFrame.Add (this.videoAlignment);
			this.videoLabel = new global::Gtk.Label ();
			this.videoLabel.Name = "videoLabel";
			this.videoLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Video</b>");
			this.videoLabel.UseMarkup = true;
			this.videoFrame.LabelWidget = this.videoLabel;
			this.settingsTable.Add (this.videoFrame);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.settingsTable[this.videoFrame]));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child settingsTable.Gtk.Table+TableChild
			this.volumeFrame = new global::Gtk.Frame ();
			this.volumeFrame.Name = "volumeFrame";
			this.volumeFrame.ShadowType = ((global::Gtk.ShadowType)(4));
			this.volumeFrame.BorderWidth = ((uint)(5));
			// Container child volumeFrame.Gtk.Container+ContainerChild
			this.volumeAlignment = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.volumeAlignment.Name = "volumeAlignment";
			this.volumeAlignment.LeftPadding = ((uint)(12));
			this.volumeAlignment.BorderWidth = ((uint)(5));
			// Container child volumeAlignment.Gtk.Container+ContainerChild
			this.volumeTable = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.volumeTable.Name = "volumeTable";
			this.volumeTable.RowSpacing = ((uint)(6));
			this.volumeTable.ColumnSpacing = ((uint)(6));
			// Container child volumeTable.Gtk.Table+TableChild
			this.critterLabel = new global::Gtk.Label ();
			this.critterLabel.Name = "critterLabel";
			this.critterLabel.Xalign = 1f;
			this.critterLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Critters");
			this.volumeTable.Add (this.critterLabel);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.critterLabel]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child volumeTable.Gtk.Table+TableChild
			this.CritterSlider = new global::Gtk.HScale (null);
			this.CritterSlider.CanFocus = true;
			this.CritterSlider.Name = "CritterSlider";
			this.CritterSlider.Adjustment.Upper = 100;
			this.CritterSlider.Adjustment.PageIncrement = 10;
			this.CritterSlider.Adjustment.StepIncrement = 1;
			this.CritterSlider.DrawValue = true;
			this.CritterSlider.Digits = 0;
			this.CritterSlider.ValuePos = ((global::Gtk.PositionType)(1));
			this.volumeTable.Add (this.CritterSlider);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.CritterSlider]));
			w25.TopAttach = ((uint)(2));
			w25.BottomAttach = ((uint)(3));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child volumeTable.Gtk.Table+TableChild
			this.musicLabel = new global::Gtk.Label ();
			this.musicLabel.Name = "musicLabel";
			this.musicLabel.Xalign = 1f;
			this.musicLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Music");
			this.volumeTable.Add (this.musicLabel);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.musicLabel]));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child volumeTable.Gtk.Table+TableChild
			this.musicSlider = new global::Gtk.HScale (null);
			this.musicSlider.CanFocus = true;
			this.musicSlider.Name = "musicSlider";
			this.musicSlider.Adjustment.Upper = 100;
			this.musicSlider.Adjustment.PageIncrement = 10;
			this.musicSlider.Adjustment.StepIncrement = 1;
			this.musicSlider.DrawValue = true;
			this.musicSlider.Digits = 0;
			this.musicSlider.ValuePos = ((global::Gtk.PositionType)(1));
			this.volumeTable.Add (this.musicSlider);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.musicSlider]));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child volumeTable.Gtk.Table+TableChild
			this.soundLabel = new global::Gtk.Label ();
			this.soundLabel.Name = "soundLabel";
			this.soundLabel.Xalign = 1f;
			this.soundLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Sounds");
			this.volumeTable.Add (this.soundLabel);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.soundLabel]));
			w28.TopAttach = ((uint)(1));
			w28.BottomAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child volumeTable.Gtk.Table+TableChild
			this.soundSlider = new global::Gtk.HScale (null);
			this.soundSlider.CanFocus = true;
			this.soundSlider.Name = "soundSlider";
			this.soundSlider.Adjustment.Upper = 100;
			this.soundSlider.Adjustment.PageIncrement = 10;
			this.soundSlider.Adjustment.StepIncrement = 1;
			this.soundSlider.DrawValue = true;
			this.soundSlider.Digits = 0;
			this.soundSlider.ValuePos = ((global::Gtk.PositionType)(1));
			this.volumeTable.Add (this.soundSlider);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.volumeTable[this.soundSlider]));
			w29.TopAttach = ((uint)(1));
			w29.BottomAttach = ((uint)(2));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(2));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			this.volumeAlignment.Add (this.volumeTable);
			this.volumeFrame.Add (this.volumeAlignment);
			this.volumeLabel = new global::Gtk.Label ();
			this.volumeLabel.Name = "volumeLabel";
			this.volumeLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Volume</b>");
			this.volumeLabel.UseMarkup = true;
			this.volumeFrame.LabelWidget = this.volumeLabel;
			this.settingsTable.Add (this.volumeFrame);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.settingsTable[this.volumeFrame]));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.settingsTable);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 584;
			this.DefaultHeight = 378;
			this.Show ();
			this.cancelButton.Clicked += new global::System.EventHandler (this.OnCancelButtonClicked);
			this.applyButton.Clicked += new global::System.EventHandler (this.OnApplyButtonClicked);
		}
	}
}
