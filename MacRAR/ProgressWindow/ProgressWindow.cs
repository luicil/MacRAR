﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace MacRAR
{
	public partial class ProgressWindow : NSPanel
	{
		#region Constructors

		// Called when created from unmanaged code
		public ProgressWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public ProgressWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{


		}

		#endregion
	}
}
