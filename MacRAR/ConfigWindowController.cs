﻿using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class ConfigWindowController : NSObject 
	{

		[Export("window")]
		public ConfigWindow Window { get; set;}

		[Outlet]
		public NSTextField txt_RAR { get; set; }

		[Outlet]
		public NSTextField txt_UNRAR { get; set; }

		public string txtRAR {
			get { return txt_RAR.StringValue; }
			set { txt_RAR.StringValue = value; }
		}

		public string txtUNRAR {
			get { return txt_UNRAR.StringValue; }
			set { txt_UNRAR.StringValue = value; }
		}

		public ConfigWindowController ()
		{
			NSBundle.LoadNib ("ConfigWindow", this);
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			this.txtRAR = ioPrefs.GetStringValue ("CaminhoRAR");
			this.txtUNRAR = ioPrefs.GetStringValue ("CaminhoUNRAR");
			ioPrefs = null;
		}

		public void ShowConfigWindow(NSWindow inWindow) {
			NSApplication.SharedApplication.BeginSheet (Window, inWindow);
		}

		public void CloseConfigWindow() {
			NSApplication.SharedApplication.EndSheet (Window);
			Window.Close();
		}

		[Export ("btn_Cancela:")]
		void btn_Cancela (NSObject sender) {
			CloseConfigWindow();
		}

		[Export ("btn_Confirma:")]
		void btn_Confirma (NSObject sender) {
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			ioPrefs.SetStringValue("CaminhoRAR",this.txtRAR );
			ioPrefs.SetStringValue ("CaminhoUNRAR", this.txtUNRAR);
			ioPrefs = null;
			CloseConfigWindow();
		}

		[Export ("btn_CaminhoRAR:")]
		void btn_CaminhoRAR (NSObject sender)
		{
			this.txtRAR = this.OpenDialog ();
		}

		[Export ("btn_CaminhoUNRAR:")]
		void btn_CaminhoUNRAR (NSObject sender)
		{
			this.txtUNRAR = this.OpenDialog ();
		}

		string OpenDialog()
		{
			string path = string.Empty;
			NSOpenPanel dlg = NSOpenPanel.OpenPanel;
			dlg.CanChooseFiles = true;
			dlg.CanChooseDirectories = false;
			if (dlg.RunModal () == 1)
			{
				NSUrl url = dlg.Urls [0];

				if (url != null) {
					path = url.Path;
				}
			}

			return path;

		}

	}
}
